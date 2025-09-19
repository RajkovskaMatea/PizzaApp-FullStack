namespace PizzaApp.DTOs.UserDTOs
{
    public class RegisterUserDTO
    {
        public string LastName { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;

        public string Username { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string ConfirmPassword { get; set; } = string.Empty;

        public long PhoneNumber { get; set; }

        public string Address { get; set; } = string.Empty;
    }
}
