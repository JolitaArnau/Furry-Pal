using System.Threading.Tasks;

namespace FurryPal.Services.Contracts
{
    using Models;
    
    public interface IManufacturerAdminService
    {
        Task CreateManufacturerAsync(string name, string email, string phoneNumber);

        Task<Manufacturer[]> GetAllManufacturersAsync();
        
        Task<bool> ManufacturerExistsAsync(string name);
        
        Task<Manufacturer> GetManufacturerByIdAsync(string id);

        Task EditManufacturerAsync(string id, string name, string email, string phoneNumber);

        Task DeleteManufacturerAsync(string id);
    }
}