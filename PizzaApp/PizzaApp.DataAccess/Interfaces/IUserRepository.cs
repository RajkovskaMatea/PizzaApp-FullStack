namespace PizzaApp.DataAccess.Interfaces
{
    using PizzaApp.Domain.Entities;

    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByUsername(string username);

        Task<bool> ValidateUsername(string username);
    }
}
