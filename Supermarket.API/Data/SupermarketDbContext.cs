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
            builder.Entity<Category>()
                    .HasIndex(p => new { p.Id })
                    .IsUnique();

            builder.Entity<Product>()
                    .HasIndex(p => new { p.Id })
                    .IsUnique();

            builder.Entity<Product>()
                .HasOne(c => c.Category)
                .WithMany(p => p.Products)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}