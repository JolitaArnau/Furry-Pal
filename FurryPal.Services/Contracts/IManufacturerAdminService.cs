namespace FurryPal.Services.Contracts
{
    using Models;
    
    public interface IManufacturerAdminService
    {
        void CreateManufacturer(string name, string email, string phoneNumber);

        Manufacturer[] GetAllManufacturers();
    }
}