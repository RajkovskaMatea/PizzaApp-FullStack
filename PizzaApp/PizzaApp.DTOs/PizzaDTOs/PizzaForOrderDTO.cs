using PizzaApp.Domain.Enums;

namespace PizzaApp.DTOs.PizzaDTOs
{
    public class PizzaForOrderDTO
    {
        public int PizzaId { get; set; }

        public PizzaSize PizzaSize { get; set; }

        public decimal PizzaPrice { get; set; }

        public int Count { get; set; }
    }
}
