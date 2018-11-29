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

        public async Task EditCategoryAsync(string id, string name, string description)
        {            
            var category = await GetCategoryByIdAsync(id);

            category.Name = name;
            category.Description = description;

            this.dbContext.Categories.Update(category);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task DeleteCategoryAsync(string id)
        {
            var category = await this.dbContext.Categories.FirstOrDefaultAsync(c => c.Id.Equals(id));

            this.dbContext.Categories.Remove(category);
            await this.dbContext.SaveChangesAsync();
        }

        public Task<bool> CategoryExistsAsync(string name)
        {
            var exists = this.dbContext.Categories.AnyAsync(c => c.Name.Equals(name));

            return exists;
        }

        public async Task<Category> GetCategoryByIdAsync(string id)
        {
            var category = await this.dbContext.Categories.FirstOrDefaultAsync(c => c.Id.Equals(id));

            return category;
        }

        public async Task<Category[]> GetAllCategoriesAsync()
        {
            var categories = await this.dbContext.Categories.ToArrayAsync();

            return categories;
        }
    }
}