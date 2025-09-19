using PizzaApp.Domain.Enums;

namespace PizzaApp.Domain.Entities
{
    public class PizzaOrder : BaseEntity
    {
        public int OrderId { get; set; }

        public Order Order { get; set; }

        public int PizzaId { get; set; }

        public Pizza Pizza { get; set; }

        public PizzaSize PizzaSize { get; set; }

        public int Count { get; set; }
    }
}
