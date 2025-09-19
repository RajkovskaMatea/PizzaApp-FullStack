namespace PizzaApp.DTOs.UserDTOs
{
    public class UserDTO
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = String.Empty;

        public string LastName { get; set; } = String.Empty;

        public string Address { get; set; } = String.Empty;

        public string Username { get; set; } = String.Empty;

        public string Password { get; set; } = String.Empty;

        public long PhoneNumber { get; set; }

        public string Token { get; set; } = String.Empty;
    }
}
