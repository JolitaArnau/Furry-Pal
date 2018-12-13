namespace FurryPal.Services.Products
{
    using System.Threading.Tasks;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using Data;
    using Models;
    using Contracts;

    public class ProductCustomerService : IProductCustomerService
    {
        private readonly FurryPalDbContext dbContext;

        public ProductCustomerService(FurryPalDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Product[]> GetAllLeashes()
        {
            var leashes = await this.dbContext.Products
                .Include(c => c.Category)
                .Include(m => m.Manufacturer)
                .Where(p => p.Category.Name == "Leashes").ToArrayAsync();

            return leashes;
        }

        public async Task<Product[]> GetAllToys()
        {
            var toys = await this.dbContext.Products
                .Include(c => c.Category)
                .Include(m => m.Manufacturer)
                .Where(p => p.Category.Name == "Toys").ToArrayAsync();

            return toys;
        }

        public async Task<Product[]> GetAllBowls()
        {
            var bowls = await this.dbContext.Products
                .Include(c => c.Category)
                .Include(m => m.Manufacturer)
                .Where(p => p.Category.Name == "Bowls").ToArrayAsync();

            return bowls;
        }

        public async Task<Product[]> GetAllBeds()
        {
            var beds = await this.dbContext.Products
                .Include(c => c.Category)
                .Include(m => m.Manufacturer)
                .Where(p => p.Category.Name == "Beds").ToArrayAsync();

            return beds;
        }

        public async Task<Product[]> GetAllFood()
        {
            var food = await this.dbContext.Products
                .Include(c => c.Category)
                .Include(m => m.Manufacturer)
                .Where(p => p.Category.Name == "Food").ToArrayAsync();

            return food;
        }

        public async Task<Product[]> GetAllCollars()
        {
            var collars = await this.dbContext.Products
                .Include(c => c.Category)
                .Include(m => m.Manufacturer)
                .Where(p => p.Category.Name == "Collars").ToArrayAsync();

            return collars;
        }
        
        public Product GetProductById(string id)
        {
            var product = this.dbContext.Products.FirstOrDefault(p => p.Id.Equals(id));

            return product;
        }
    }
}