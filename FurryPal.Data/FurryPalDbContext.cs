using Microsoft.AspNetCore.Identity;
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

        public DbSet<SubscriptionPurchase> SubscribedPurchases { get; set; }

        public DbSet<Sale> OnSale { get; set; }

        public DbSet<ProductReview> ProductReviews { get; set; }

        public DbSet<Receipt> Receipts { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<SubCategory> SubCategories { get; set; }

        public DbSet<Keyword> Keywords { get; set; }

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