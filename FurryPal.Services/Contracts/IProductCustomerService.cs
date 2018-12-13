namespace FurryPal.Services.Contracts
{
    using System.Threading.Tasks;
    using FurryPal.Models;

    public interface IProductCustomerService
    {
        Task<Product[]> GetAllLeashes();
        
        Task<Product[]> GetAllToys();
        
        Task<Product[]> GetAllBowls();
        
        Task<Product[]> GetAllBeds();
        
        Task<Product[]> GetAllFood();
        
        Task<Product[]> GetAllCollars();

        Product GetProductById(string id);
    }
}