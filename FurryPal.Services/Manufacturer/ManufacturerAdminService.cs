namespace FurryPal.Services.Manufacturer
{
    using System.Linq;
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

        public void CreateManufacturer(string name, string email, string phoneNumber)
        {
            var manufacturer = new Manufacturer()
            {
                Name = name,
                Email = email,
                PhoneNumber = phoneNumber
            };

            if (!dbContext.Manufacturers.Contains(manufacturer))
            {
                this.dbContext.Manufacturers.Add(manufacturer);
                this.dbContext.SaveChanges();
            }
        }

        public Manufacturer[] GetAllManufacturers()
        {
            return this.dbContext.Manufacturers.ToArray();
        }
    }
}