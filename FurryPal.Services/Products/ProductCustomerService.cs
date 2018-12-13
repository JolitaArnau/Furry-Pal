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
            var leashes = await this.dbContext.Products.Where(p => p.Category.Name == "Leashes").ToArrayAsync();

            return leashes;
        }
    }
}