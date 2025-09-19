namespace PizzaApp.DTOs.PizzaDTOs
{
    public class PizzaListDTO
    {
        public int Id { get; set; }

        public string PizzaName { get; set; } = string.Empty;

        public decimal PizzaPriceSmall { get; set; }

        public decimal PizzaPriceMedium { get; set; }

        public decimal PizzaPriceLarge { get; set; }

        public string Ingredients { get; set; } = string.Empty;
    }
}
