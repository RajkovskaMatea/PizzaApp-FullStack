namespace PizzaApp.DataAccess
{
    using Microsoft.EntityFrameworkCore;
    using PizzaApp.Domain.Entities;

    public class PizzaAppDbContext : DbContext
    {
        public PizzaAppDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        public DbSet<User> Users { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Pizza> Pizzas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Relations
            #region Relations

            modelBuilder.Entity<User>()
                .HasMany(x => x.Orders)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<Order>()
                .HasMany(x => x.PizzaOrders)
                .WithOne(x => x.Order)
                .HasForeignKey(x => x.OrderId);

            modelBuilder.Entity<Pizza>()
                .HasMany(x => x.PizzaOrders)
                .WithOne(x => x.Pizza)
                .HasForeignKey(x => x.PizzaId);

            #endregion

            //Constraints

            #region User

            modelBuilder.Entity<User>()
                 .Property(x => x.FirstName)
                 .HasMaxLength(200)
                 .IsRequired();

            modelBuilder.Entity<User>()
                .Property(x => x.LastName)
                .HasMaxLength(200)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(x => x.Address)
                .HasMaxLength(200)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(x => x.PhoneNumber)
                .HasColumnType("bigint")
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(x => x.Username)
                .HasMaxLength(20)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(x => x.Password)
                .HasMaxLength(100)
                .IsRequired();

            #endregion

            #region Pizza

            modelBuilder.Entity<Pizza>()
                .Property(x => x.Name)
                .HasMaxLength(200)
                .IsRequired();

            modelBuilder.Entity<Pizza>()
                .Property(x => x.PriceSmall)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            modelBuilder.Entity<Pizza>()
                .Property(x => x.PriceMedium)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            modelBuilder.Entity<Pizza>()
                .Property(x => x.PriceLarge)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            modelBuilder.Entity<Pizza>()
                .Property(x => x.Ingredients)
                .HasMaxLength(500)
                .IsRequired();

            #endregion

            #region Order

            modelBuilder.Entity<Order>()
                .Property(x => x.TotalPrice)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            modelBuilder.Entity<Order>()
                .Property(x => x.PaymentMethod)
                .HasConversion<int>()
                .IsRequired();

            #endregion

            #region PizzaOrder

            modelBuilder.Entity<PizzaOrder>()
                .Property(po => po.PizzaSize)
                .HasConversion<int>();

            #endregion
        }
    }
}
