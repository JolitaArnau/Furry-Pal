using Microsoft.EntityFrameworkCore;

namespace FurryPal.Services.Products
{
    using System.Threading.Tasks;
    using Data;
    using Models;
    using Contracts;

    public class ProductAdminService : IProductAdminService
    {
        private readonly FurryPalDbContext dbContext;
        private readonly ICategoryAdminService categoryAdminService;
        private readonly IManufacturerAdminService manufacturerService;

        public ProductAdminService(FurryPalDbContext dbContext, ICategoryAdminService categoryAdminService,
            IManufacturerAdminService manufacturerAdminService)
        {
            this.dbContext = dbContext;
            this.categoryAdminService = categoryAdminService;
            this.manufacturerService = manufacturerAdminService;
        }

        public async Task CreateProductAsync(string productCode, string name, string description, string categoryId,
            string manufacturerId, decimal price, int stockQuantity)
        {
            var product = new Product()
            {
                ProductCode = productCode,
                Name = name,
                Description = description,
                Category = categoryAdminService.GetCategoryByIdAsync(categoryId).Result,
                Manufacturer = manufacturerService.GetManufacturerByIdAsync(manufacturerId).Result,
                Price = price,
                StockQuantity = stockQuantity
            };

            if (!this.ProductExistsAsync(name).Result)
            {
                await this.dbContext.Products.AddAsync(product);
                await this.dbContext.SaveChangesAsync();
            }
        }

        public Task<bool> ProductExistsAsync(string name)
        {
            var exists = this.dbContext.Categories.AnyAsync(c => c.Name.Equals(name));

            return exists;
        }

        public Task<Product[]> GetAllProductsAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}