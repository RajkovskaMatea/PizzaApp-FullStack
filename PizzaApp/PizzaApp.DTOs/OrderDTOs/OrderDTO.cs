using PizzaApp.Domain.Enums;
using PizzaApp.DTOs.PizzaDTOs;

namespace PizzaApp.DTOs.OrderDTOs
{
    public class OrderDTO
    {
        public List<PizzaForOrderDTO> PizzasForOrder { get; set; } = new List<PizzaForOrderDTO>();

        public int UserId { get; set; }

        public PaymentMethod PaymentMethod { get; set; }
    }
}
