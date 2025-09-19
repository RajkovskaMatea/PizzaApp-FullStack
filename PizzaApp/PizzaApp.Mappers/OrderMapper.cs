namespace PizzaApp.Mappers
{
    using PizzaApp.Domain.Entities;
    using PizzaApp.Domain.Enums;
    using PizzaApp.DTOs.OrderDTOs;
    using PizzaApp.DTOs.PizzaDTOs;

    public static class OrderMapper
    {
        public static OrderListDTO ToOrderListDTO(this Order order)
        {
            return new OrderListDTO()
            {
                Id = order.Id,
                UserId = order.UserId,
                PizzasInOrder = order.PizzaOrders.Select(x => new PizzaDTO
                {
                    Id = x.Pizza.Id,
                    PizzaName = x.Pizza.Name,
                    PizzaPrice = (x.PizzaSize == PizzaSize.Small ? x.Pizza.PriceSmall :
                                 x.PizzaSize == PizzaSize.Medium ? x.Pizza.PriceMedium :
                                 x.Pizza.PriceLarge) * x.Count,
                    PizzaSize = x.PizzaSize,
                    Count = x.Count
                }).ToList()
            };
        }

        
    }
}
