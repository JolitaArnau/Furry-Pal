namespace FurryPal.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Models;

    public interface IProductAdminService
    {
        Task CreateProductAsync(string productCode, string name, string description, string categoryId,
            string manufacturerId,
            decimal price, int stockQuantity, string imageUrl);

        Task<Product[]> GetAllProductsAsync();

        List<SelectListItem> GetCategories();

        List<SelectListItem> GetManufacturers();

        Task<bool> ProductExistsAsync(string name);

        Task<Product> GetProductByIdAsync(string id);

        Task EditProductAsync(string id, string productCode, string name, string description,
            decimal price, int stockQuantity);

        Task DeleteProductAsync(string id);
    }
}