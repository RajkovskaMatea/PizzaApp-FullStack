namespace PizzaApp.Domain.Entities
{
    public class Pizza : BaseEntity
    {
        public string Name { get; set; } = String.Empty;

        public decimal PriceSmall { get; set; }

        public decimal PriceMedium { get; set; }

        public decimal PriceLarge { get; set; }

        public string Ingredients { get; set; } = String.Empty;

        public List<PizzaOrder> PizzaOrders { get; set; } = new List<PizzaOrder>();
    }
}
