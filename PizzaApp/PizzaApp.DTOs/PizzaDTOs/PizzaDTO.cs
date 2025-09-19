namespace PizzaApp.DTOs.PizzaDTOs
{
    using PizzaApp.Domain.Enums;

    public class PizzaDTO
    {
        public int Id { get; set; }

        public string PizzaName { get; set; } = string.Empty;

        public decimal PizzaPrice { get; set; }

        public PizzaSize PizzaSize { get; set; }

        public int Count { get; set; }
    }
}
