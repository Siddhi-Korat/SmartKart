using Microsoft.EntityFrameworkCore;
using SmartCart.Repo.Model;
using System;

namespace SmartCart.Repo.Context
{
    public class SmartCartDBContext : DbContext
    {
        public SmartCartDBContext(DbContextOptions<SmartCartDBContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<GoodsCategory> GoodsCategories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }
            modelBuilder.Entity<Order>().HasMany(o => o.OrderItems).WithOne(item => item.Order);
            //modelBuilder.Entity<Item>().HasOne(c => c.Category).WithMany(i => i.Items);
        }
    }
}
