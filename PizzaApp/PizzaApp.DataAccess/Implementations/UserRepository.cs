namespace PizzaApp.DataAccess.Implementations
{
    using Microsoft.EntityFrameworkCore;
    using PizzaApp.DataAccess.Interfaces;
    using PizzaApp.Domain.Entities;

    public class UserRepository : IUserRepository
    {
        private PizzaAppDbContext _dbContext;
        public UserRepository(PizzaAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> Create(User entity)
        {
            await _dbContext.Users.AddAsync (entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<User> GetById(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<User>> GetAll(int? userId = null)
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<int> DeleteById(int id)
        {
            var toBeRemoved = await GetById(id);
            _dbContext.Users.Remove(toBeRemoved);
            await _dbContext.SaveChangesAsync();
            return id;
        }

        public async Task<User> UpdateById(User entity)
        {
            _dbContext.Users.Update(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<User> GetByUsername(string username)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Username == username);
        }

        public async Task<bool> ValidateUsername(string username)
        {
            return await _dbContext.Users.AnyAsync(x => x.Username == username);
        }
    }
}
