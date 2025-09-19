namespace PizzaApp.Mappers
{
    using PizzaApp.Domain.Entities;
    using PizzaApp.DTOs.UserDTOs;

    public static class UserMapper
    {
        public static UserListDTO ToUserListDTO(this User user)
        {
            return new UserListDTO()
            {
                Id = user.Id,
                FullName = $"{user.FirstName} {user.LastName}"
            };
        }

        public static User ToUser(this UserDTO model, string hashedPassword)
        {
            return new User()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Username = model.Username,
                Password = hashedPassword,
                PhoneNumber = model.PhoneNumber,
                Address = model.Address
            };
        }
    }
}
