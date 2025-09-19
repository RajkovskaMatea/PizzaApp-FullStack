namespace PizzaApp.Services.Interfaces
{
    using PizzaApp.DTOs.OrderDTOs;
    public interface IOrderService
    {
        Task<List<OrderListDTO>> GetAllOrders(int userId);

        Task SubmitOrder(OrderDTO order);
    }
}
