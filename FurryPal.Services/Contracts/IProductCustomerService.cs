namespace FurryPal.Services.Contracts
{
    using System.Threading.Tasks;
    using FurryPal.Models;
    
    public interface IProductCustomerService
    {
        Task<Product[]> GetAllLeashes();
    }
}