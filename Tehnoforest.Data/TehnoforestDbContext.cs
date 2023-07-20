﻿namespace Tehnoforest.Data
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using System.Reflection;
    using Tehnoforest.Data.Models;

    public class TehnoforestDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public TehnoforestDbContext(DbContextOptions<TehnoforestDbContext> options)
            : base(options)
        {

        }

        public DbSet<Automower> Automowers { get; set; } = null!;
        public DbSet<Chainsaw> Chainsaws { get; set; } = null!;
        public DbSet<GardenTractor> GardenTractors { get; set; } = null!;
        public DbSet<GrassTrimmer> GrassTrimmers { get; set; } = null!;
        public DbSet<LawnMower> LawnMowers { get; set; } = null!;

        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            Assembly configAssembly = Assembly.GetAssembly(typeof(TehnoforestDbContext)) ?? 
                                      Assembly.GetExecutingAssembly();
            builder.ApplyConfigurationsFromAssembly(configAssembly);

            base.OnModelCreating(builder);
        }
    }
}