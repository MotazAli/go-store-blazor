using GoStore.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoStore.Data.Database
{
    public class GoStoreDbContext : DbContext 
    {

        public GoStoreDbContext(DbContextOptions<GoStoreDbContext> dbContextOptions) 
            : base(dbContextOptions)
        {
        }

        public DbSet<Cart> Carts  => Set<Cart>();
        public DbSet<CartItem> CartItems => Set<CartItem>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Category> Categories => Set<Category>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GoStoreDbContext).Assembly);
        }
    }


    class GoStoreDbContextContextFactory : IDesignTimeDbContextFactory<GoStoreDbContext>
    {
        public GoStoreDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var optionsBuilder = new DbContextOptionsBuilder<GoStoreDbContext>();
            optionsBuilder.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]);

            return new GoStoreDbContext(optionsBuilder.Options);
        }
    }

}
