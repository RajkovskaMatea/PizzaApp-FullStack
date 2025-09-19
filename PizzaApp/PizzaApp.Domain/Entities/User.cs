namespace PizzaApp.Domain.Entities
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; } = String.Empty;

        public string LastName { get; set; } = String.Empty;

        public string Address { get; set; } = String.Empty;

        public string Username { get; set; } = String.Empty;

        public string Password { get; set; } = String.Empty;

        public long PhoneNumber { get; set; }

        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
