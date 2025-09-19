namespace PizzaApp.DataAccess.Interfaces
{
    using PizzaApp.Domain.Entities;

    public interface IPizzaRepository : IRepository<Pizza>
    {
        Task<List<Pizza>> GetPizzasById(List<int> ids);
    }
}
