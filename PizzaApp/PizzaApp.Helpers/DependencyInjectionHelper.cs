namespace PizzaApp.Helpers
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using PizzaApp.DataAccess;
    using PizzaApp.DataAccess.Implementations;
    using PizzaApp.DataAccess.Interfaces;
    using PizzaApp.Domain.Entities;
    using PizzaApp.Services.Implementations;
    using PizzaApp.Services.Interfaces;

    public static class DependencyInjectionHelper
    {
        public static void InjectDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<PizzaAppDbContext>(options =>
            options.UseSqlServer(connectionString));
        }

        public static void InjectRepositories(this IServiceCollection services)
        {
            services.AddTransient<IPizzaRepository, PizzaRepository>();
            services.AddTransient<IRepository<Order>, OrderRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
        }

        public static void InjectServices(this IServiceCollection services)
        {
            services.AddTransient<IPizzaService, PizzaService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IUserService,  UserService>();
        }
    }
}
