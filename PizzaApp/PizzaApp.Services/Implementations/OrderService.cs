namespace PizzaApp.Services.Implementations
{
    using PizzaApp.DataAccess.Interfaces;
    using PizzaApp.Domain.Entities;
    using PizzaApp.DTOs.OrderDTOs;
    using PizzaApp.Services.Interfaces;
    using PizzaApp.Mappers;

    public class OrderService : IOrderService
    {
        private IRepository<Order> _orderRepository;
        private IUserRepository _userRepository;
        private IPizzaRepository _pizzaRepository;

        public OrderService(IRepository<Order> orderRepository,
                            IPizzaRepository pizzaRepository,
                            IUserRepository userRepository)
        {
            _orderRepository = orderRepository;
            _pizzaRepository = pizzaRepository;
            _userRepository  = userRepository;
        }

        public async Task<List<OrderListDTO>> GetAllOrders(int userId)
        {
            var result = await _orderRepository.GetAll(userId);

            var resultConverted = result.Select(order => order.ToOrderListDTO()).ToList();

            return resultConverted;
        }

        public async Task SubmitOrder(OrderDTO order)
        {
            User user = await _userRepository.GetById(order.UserId);
            if (user == null)
            {
                throw new Exception($"User with id {order.UserId} was not found!");
            }

            var pizzaIds = order.PizzasForOrder.Select(p => p.PizzaId).ToList();
            var allPizzas = await _pizzaRepository.GetPizzasById(pizzaIds);
            var pizzaOrders = new List<PizzaOrder>();

            var newOrder = new Order()
            {
                PaymentMethod = order.PaymentMethod,
                TotalPrice = (double)order.PizzasForOrder.Sum(p => p.PizzaPrice * p.Count),
                User = user,
                UserId = user.Id
            };

            foreach (var dto in order.PizzasForOrder)
            {
                var pizza = allPizzas.First(p => p.Id == dto.PizzaId);
                var pizzaOrder = new PizzaOrder()
                {
                    Order = newOrder,
                    Pizza = pizza,
                    PizzaId = pizza.Id,
                    PizzaSize = dto.PizzaSize,
                    Count = dto.Count
                };
                pizzaOrders.Add(pizzaOrder);
            }

            newOrder.PizzaOrders = pizzaOrders;
            var orderCreated = await _orderRepository.Create(newOrder);
            int newOrderId = orderCreated.Id;
            if (newOrderId <= 0)
            {
                throw new Exception("An error occured while saving to db");
            }
        }

    }
}
