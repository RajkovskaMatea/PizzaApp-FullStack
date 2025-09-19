using Microsoft.EntityFrameworkCore;
using PizzaApp.DataAccess.Interfaces;
using PizzaApp.Domain.Entities;


namespace PizzaApp.DataAccess.Implementations
{
    public class OrderRepository : IRepository<Order>
    {
        private PizzaAppDbContext _dbContext;

        public OrderRepository(PizzaAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Order> Create(Order entity)
        {
            await _dbContext.Orders.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<Order> GetById(int id)
        {
            return await _dbContext.Orders.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Order>> GetAll(int? userId)
        {
            return await _dbContext.Orders
                .Where(x=>x.UserId == userId)
                .Include(x => x.PizzaOrders)
                .ThenInclude(x => x.Pizza)
                .ToListAsync();
        }

        public async Task<int> DeleteById(int id)
        {
            var toBeRemoved = await GetById(id);
            _dbContext.Orders.Remove(toBeRemoved);
            await _dbContext.SaveChangesAsync();
            return id;
        }

        public async Task<Order> UpdateById(Order entity)
        {
            _dbContext.Orders.Update(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }
    }
}
