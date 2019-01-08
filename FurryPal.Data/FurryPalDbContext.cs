using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FurryPal.Data
{
    using System.IO;
    using Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using Microsoft.Extensions.Configuration;

    public class FurryPalDbContext : IdentityDbContext<User, IdentityRole, string>
    {
        public FurryPalDbContext(DbContextOptions<FurryPalDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Manufacturer> Manufacturers { get; set; }

        public DbSet<Purchase> Purchases { get; set; }

        public DbSet<AutoShippingPurchase> SubscribedPurchases { get; set; }

        public DbSet<Keyword> Keywords { get; set; }

        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

        public DbSet<ProductPurchase> ProductsPurchases { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductPurchase>()
                .HasKey(pp => pp.Id);

            modelBuilder.Entity<ProductPurchase>()
                .HasOne(p => p.Product)
                .WithMany(p => p.ProductPurchases)
                .HasForeignKey(p => p.ProductId);

            modelBuilder.Entity<ProductPurchase>()
                .HasOne(p => p.Purchase)
                .WithMany(p => p.ProductPurchases)
                .HasForeignKey(p => p.PurchaseId);

            modelBuilder.Entity<Purchase>()
                .HasOne(u => u.User)
                .WithMany(p => p.Purchases);

            base.OnModelCreating(modelBuilder);
        }


        public class FurryPalDbContextContextFactory
            : IDesignTimeDbContextFactory<FurryPalDbContext>
        {
            public FurryPalDbContext CreateDbContext(string[] args)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("developerEnvConnectionString.json")
                    .Build();

                var builder = new DbContextOptionsBuilder<FurryPalDbContext>();

                var configurationString = configuration["ConnectionString:DefaultConnection"];

                builder.UseSqlServer(configurationString);

                return new FurryPalDbContext(builder.Options);
            }
        }
    }
}