namespace FurryPal.Services.Manufacturer
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Contracts;
    using Models;
    using Data;

    public class ManufacturerAdminService : IManufacturerAdminService
    {
        private readonly FurryPalDbContext dbContext;

        public ManufacturerAdminService(FurryPalDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateManufacturerAsync(string name, string email, string phoneNumber)
        {
            var manufacturer = new Manufacturer()
            {
                Name = name,
                Email = email,
                PhoneNumber = phoneNumber
            };

            if (!dbContext.Manufacturers.Contains(manufacturer))
            {
                await this.dbContext.Manufacturers.AddAsync(manufacturer);
                await this.dbContext.SaveChangesAsync();
            }
        }

        public async Task EditManufacturerAsync(string id, string name, string email, string phoneNumber)
        {
            var manufacturer = await this.dbContext.Manufacturers.FirstOrDefaultAsync(c => c.Id.Equals(id));

            manufacturer.Name = name;
            manufacturer.Email = email;
            manufacturer.PhoneNumber = phoneNumber;

            this.dbContext.Manufacturers.Update(manufacturer);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task DeleteManufacturerAsync(string id)
        {
            var manufacturer = await GetManufacturerByIdAsync(id);

            this.dbContext.Manufacturers.Remove(manufacturer);
            await this.dbContext.SaveChangesAsync();
        }

        public Task<bool> ManufacturerExistsAsync(string name)
        {
            var exists = this.dbContext.Manufacturers.AnyAsync(c => c.Name.Equals(name));

            return exists;
        }

        public async Task<Manufacturer> GetManufacturerByIdAsync(string id)
        {
            var manufacturer = await this.dbContext.Manufacturers.FirstOrDefaultAsync(c => c.Id.Equals(id));

            return manufacturer;
        }

        public async Task<Manufacturer[]> GetAllManufacturersAsync()
        {
            var manufacturers = await this.dbContext.Manufacturers.ToArrayAsync();

            return manufacturers;
        }
    }
}