using System.Threading.Tasks;

namespace FurryPal.Services.Contracts
{
    using Models;

    public interface IProductAdminService
    {
        Task CreateProductAsync(string productCode, string name, string description, string categoryId,
            string manufacturerId, decimal price,int stockQuantity);

        Task<Product[]> GetAllProductsAsync();
    }
}