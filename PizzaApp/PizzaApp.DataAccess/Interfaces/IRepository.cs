using PizzaApp.Domain.Entities;

namespace PizzaApp.DataAccess.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> GetById(int id);

        Task<List<T>> GetAll(int? userId = null);

        Task<int> DeleteById(int id);

        Task<T> UpdateById(T entity);

        Task<T> Create(T entity);
    }
}
