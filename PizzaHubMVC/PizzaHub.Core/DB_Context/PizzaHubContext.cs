using Microsoft.EntityFrameworkCore;
using PizzaHub.Core.Config;
using PizzaHub.Core.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaHub.Core.DB_Context
{
    public class PizzaHubContext : DbContext
    {
        public PizzaHubContext(DbContextOptions<PizzaHubContext> option): base(option)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<User> Users { get; set; }

        public void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductMapConfig());
            modelBuilder.ApplyConfiguration(new CartMapConfig());
            modelBuilder.ApplyConfiguration(new CartItemMapConfig());
            modelBuilder.ApplyConfiguration(new  UserMapConfig());  
        }
    }
}
