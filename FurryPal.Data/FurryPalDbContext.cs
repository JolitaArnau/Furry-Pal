using Microsoft.AspNetCore.Identity;

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

        public DbSet<Category> Categories { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Manufacturer> Manufacturers { get; set; }

        public DbSet<Purchase> Purchases { get; set; }

        public DbSet<SubscriptionPurchase> SubscriptionPurchases { get; set; }

        public DbSet<Sale> Sales { get; set; }

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