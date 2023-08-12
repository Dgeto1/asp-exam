namespace Tehnoforest.Data
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using System.Reflection;
    using Tehnoforest.Data.Configurations;
    using Tehnoforest.Data.Models;

    public class TehnoforestDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        //private readonly bool seedDb;
        public TehnoforestDbContext(DbContextOptions<TehnoforestDbContext> options)
            : base(options)
        {
            //this.seedDb = seedDb;
        }

        public DbSet<Product> Products { get; set; } = null!;

        public DbSet<RepairServiceProduct> RepairServiceProducts { get; set; } = null!;

        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<OrderItem> OrderItems { get; set; } = null!;
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder builder)
        {
            Assembly configAssembly = Assembly.GetAssembly(typeof(TehnoforestDbContext)) ??
                                     Assembly.GetExecutingAssembly();
            builder.ApplyConfigurationsFromAssembly(configAssembly);

            //builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
            //builder.ApplyConfiguration(new ProductsEntityConfiguration());
            //if (this.seedDb)
            //{
            //    builder.ApplyConfiguration(new RepairServiceEntityConfiguration());
            //    builder.ApplyConfiguration(new OrdersConfiguration());
            //}

            base.OnModelCreating(builder);
        }
    }
}