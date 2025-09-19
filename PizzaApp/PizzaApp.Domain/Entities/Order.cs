namespace PizzaApp.Domain.Entities
{
    using PizzaApp.Domain.Enums;

    public class Order : BaseEntity
    {
        public int UserId { get; set; }

        public User User { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public double TotalPrice { get; set; }

        public List<PizzaOrder> PizzaOrders { get; set; } = new List<PizzaOrder>();
    }
}
