namespace FurryPal.Services.Categories
{
    using System.Linq;
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

        public void CreateCategory(string name, string description)
        {
            var category = new Category()
            {
                Name = name,
                Description = description
            };

            if (!dbContext.Categories.Contains(category))
            {
                this.dbContext.Categories.Add(category);
                this.dbContext.SaveChanges();
            }
        }

        public Category[] GetAllCategories()
        {
            return this.dbContext.Categories.ToArray();
        }
    }
}