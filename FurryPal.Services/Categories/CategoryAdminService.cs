namespace FurryPal.Services.Categories
{
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Data;
    using Models;
    using Contracts;


    public class CategoryAdminService : ICategoryAdminService
    {
        private readonly FurryPalDbContext dbContext;

        public CategoryAdminService(FurryPalDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateCategoryAsync(string name, string description)
        {
            var category = new Category()
            {
                Name = name,
                Description = description
            };

            if (!this.CategoryExistsAsync(name).Result)
            {
                await this.dbContext.Categories.AddAsync(category);
                await this.dbContext.SaveChangesAsync();
            }
        }

        public Task<bool> CategoryExistsAsync(string name)
        {
            var exists = this.dbContext.Categories.AnyAsync(c => c.Name.Equals(name));

            return exists;
        }

        public async Task<Category[]> GetAllCategoriesAsync()
        {
            var categories = await this.dbContext.Categories.ToArrayAsync();

            return categories;
        }
    }
}