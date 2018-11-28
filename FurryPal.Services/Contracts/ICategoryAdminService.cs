using System.Threading.Tasks;

namespace FurryPal.Services.Contracts
{
    using Models;
    
    public interface ICategoryAdminService
    {
        Task CreateCategoryAsync(string name, string description);

        Task<Category[]> GetAllCategoriesAsync();

        Task<bool> CategoryExistsAsync(string name);
        
        Task<Category> GetCategoryByIdAsync(string id);

        Task EditCategoryAsync(string id, string name, string description);

        Task DeleteCategoryAsync(string id);
    }
}