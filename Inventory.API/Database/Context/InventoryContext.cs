using Inventory.API.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.API.Database.Context
{
    public class InventoryContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
        public InventoryContext(DbContextOptions options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(c => c.CategoryItems)
                .WithOne(e => e.ItemCategory);
            modelBuilder.Entity<Item>().HasOne(c => c.ItemCategory);
        }
    }
}
