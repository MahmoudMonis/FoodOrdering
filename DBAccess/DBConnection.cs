using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using FoodOrdering.Model;
using FoodOrdering.ViewModels;

namespace FoodOrdering.DBAccess
{

    public class DBConnection : DbContext
    {


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseNpgsql("host=localhost;port=5432;dbname=postgres;user=postgres;password=123456;sslmode=prefer;connect_timeout=10");

        public DbSet<FoodItem>? fooditem { get; set; }
        public DbSet<Basket1>? Basket { get; set; }
        public DbSet<Order>? order { get; set; }
        public DbSet<OrderItems>? orderItems { get; set; }
        public DbSet<Category>? category { get; set; }
        public DbSet<Subcategory>? subcategory { get; set; }
        public DbSet<User>? Users { get; set; }
        public DbSet<Rating>? rating { get; set; }
    }



}
