namespace FurryPal.Services.Contracts
{
    using Models;
    
    public interface ICategoryAdminService
    {
        void CreateCategory(string name, string description);

        Category[] GetAllCategories();
    }
}