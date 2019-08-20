using Microsoft.EntityFrameworkCore;
using Supermarket.Common.Models;
using System;

namespace Supermarket.API.Data
{
    public class SupermarketDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get;set; }
        public DbSet<ApplicationUser> Users { get;set; }
        public DbSet<ApplicationRole> Roles { get; set; }
        public DbSet<ApplicationUserRole> UserRoles { get; set; }
        public SupermarketDbContext (DbContextOptions<SupermarketDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Category>().ToTable("Categories");
            builder.Entity<Category>().HasKey(p => p.Id);
            builder.Entity<Category>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Category>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Category>().HasMany(p => p.Products).WithOne(p => p.Category).HasForeignKey(p => p.CategoryId);
            builder.Entity<Category>().HasData
            (
                new Category { Id = Guid.Parse("9C2EE22C-5955-42BD-A596-EC7117F45789"), Name = "Electronics" },
                new Category { Id = Guid.Parse("291C0718-74B7-4844-8C0F-8E8DA4EF2551"), Name = "Merchandise" }
            );

            builder.Entity<Product>().ToTable("Products");
            builder.Entity<Product>().HasKey(p => p.Id);
            builder.Entity<Product>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Product>().Property(p => p.QuantityInStock).IsRequired();
            builder.Entity<Product>().Property(p => p.UnitOfMeasurement).IsRequired();
        }
    }
}