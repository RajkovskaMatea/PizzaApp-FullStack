namespace PizzaApp.DataAccess.Implementations
{
    using Microsoft.EntityFrameworkCore;
    using PizzaApp.DataAccess.Interfaces;
    using PizzaApp.Domain.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class PizzaRepository : IPizzaRepository
    {
        private PizzaAppDbContext _dbContext;

        public PizzaRepository(PizzaAppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<Pizza> Create(Pizza entity)
        {
            await _dbContext.Pizzas.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<int> DeleteById(int id)
        {
            var toBeRemoved = await GetById(id);
            _dbContext.Pizzas.Remove(toBeRemoved);
            await _dbContext.SaveChangesAsync();

            return id;
        }

        public async Task<List<Pizza>> GetAll(int? userId = null)
        {
            return await _dbContext.Pizzas.ToListAsync();
        }

        public async Task<Pizza> GetById(int id)
        {
            return await _dbContext.Pizzas.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Pizza>> GetPizzasById(List<int> ids)
        {
            return await _dbContext.Pizzas
                .Where(p => ids.Contains(p.Id))
                .ToListAsync();
        }

        public async Task<Pizza> UpdateById(Pizza entity)
        {
            _dbContext.Pizzas.Update(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }
    }
}
