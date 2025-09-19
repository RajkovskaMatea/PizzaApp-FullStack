namespace PizzaApp.Services.Interfaces
{
    using PizzaApp.DTOs.UserDTOs;
    public interface IUserService
    {
        Task<List<UserListDTO>> GetAllUsers();
        Task<UserDTO> Authenticate(string username, string password);
        Task Register(RegisterUserDTO model);
    }
}
