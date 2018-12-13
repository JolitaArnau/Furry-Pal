namespace FurryPal.Services.Products
{
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using Data;
    using Models;
    using Contracts;

    public class ProductAdminService : IProductAdminService
    {
        private readonly FurryPalDbContext dbContext;
        private readonly ICategoryAdminService categoryAdminService;
        private readonly IManufacturerAdminService manufacturerAdminService;
        private readonly Cloudinary cloudinary;

        public ProductAdminService(FurryPalDbContext dbContext, ICategoryAdminService categoryAdminService,
            IManufacturerAdminService manufacturerAdminService, Cloudinary cloudinary)
        {
            this.dbContext = dbContext;
            this.categoryAdminService = categoryAdminService;
            this.manufacturerAdminService = manufacturerAdminService;
            this.cloudinary = cloudinary;
        }

        public async Task CreateProductAsync(string productCode, string name, string description, string categoryId,
            string manufacturerId, decimal price,
            int stockQuantity, string imageUrl, string keywords)
        {
            var category = new Category(this.categoryAdminService.GetCategoryByIdAsync(categoryId).Result.Id,
                this.categoryAdminService.GetCategoryByIdAsync(categoryId).Result.Name,
                this.categoryAdminService.GetCategoryByIdAsync(categoryId).Result.Description);

            var manufacturer = new Manufacturer(
                this.manufacturerAdminService.GetManufacturerByIdAsync(manufacturerId).Result.Id,
                this.manufacturerAdminService.GetManufacturerByIdAsync(manufacturerId).Result.Name,
                this.manufacturerAdminService.GetManufacturerByIdAsync(manufacturerId).Result.Email,
                this.manufacturerAdminService.GetManufacturerByIdAsync(manufacturerId).Result.PhoneNumber);

            var product = new Product()
            {
                ProductCode = productCode,
                Name = name,
                Description = description,
                Category = category,
                CategoryId = categoryId,
                Manufacturer = manufacturer,
                ManufacturerId = manufacturerId,
                Price = price,
                StockQuantity = stockQuantity,
                Keywords = new HashSet<Keyword>(ProcessKeywords(keywords))
            };


            if (string.IsNullOrEmpty(imageUrl) || string.IsNullOrWhiteSpace(imageUrl))
            {
                product.ImageUrl = "https://res.cloudinary.com/dqpvoobij/image/upload/v1544518649/photos.png";
            }

            else
            {
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(imageUrl)
                };
                var uploadResult = cloudinary.Upload(uploadParams);

                product.ImageUrl = uploadResult.Uri.ToString();
            }


            if (!this.ProductExistsAsync(name).Result)
            {
                await this.dbContext.Products.AddAsync(product);
                await this.dbContext.SaveChangesAsync();
            }
        }

        public async Task<Product[]> GetAllProductsAsync()
        {
            var products = await
                this
                    .dbContext
                    .Products
                    .Include(p => p.Category)
                    .Include(p => p.Manufacturer)
                    .ToArrayAsync();

            return products;
        }

        public async Task EditProductAsync(string id, string productCode, string name, string description,
            decimal price, int stockQuantity)
        {
            var product = await GetProductByIdAsync(id);

            product.ProductCode = productCode;
            product.Name = name;
            product.Description = description;
            product.Price = price;
            product.StockQuantity = product.StockQuantity;

            this.dbContext.Products.Update(product);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(string id)
        {
           var product = await this.dbContext.Products
            .Include(k => k.Keywords)
                .FirstOrDefaultAsync(c => c.Id.Equals(id));

            dbContext.Keywords.RemoveRange(product.Keywords);
            
            this.dbContext.Products.Remove(product);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<Product> GetProductByIdAsync(string id)
        {
            var product = this.dbContext.Products.FirstOrDefaultAsync(p => p.Id.Equals(id)).Result;

            return product;
        }

        public Task<bool> ProductExistsAsync(string name)
        {
            var exists = this.dbContext.Products.AnyAsync(c => c.Name.Equals(name));

            return exists;
        }

        public List<SelectListItem> GetCategories()
        {
            var dbCategories = new List<Category>(dbContext.Categories);

            var listItems = new List<SelectListItem>();

            foreach (var category in dbCategories)
            {
                var selectListItem = new SelectListItem {Value = category.Id, Text = category.Name};

                listItems.Add(selectListItem);
            }

            return listItems;
        }

        public List<SelectListItem> GetManufacturers()
        {
            var dbManufacturers = new List<Manufacturer>(dbContext.Manufacturers);

            var listItems = new List<SelectListItem>();

            foreach (var category in dbManufacturers)
            {
                var selectListItem = new SelectListItem {Value = category.Id, Text = category.Name};

                listItems.Add(selectListItem);
            }

            return listItems;
        }

        private HashSet<Keyword> ProcessKeywords(string words)
        {
            var input = words.Split(", ").ToArray();
            var keywords = new HashSet<Keyword>();

            foreach (var word in input)
            {
                var keyword = new Keyword
                {
                    Name = word
                };

                keywords.Add(keyword);
            }

            return keywords;
        }
    }
}