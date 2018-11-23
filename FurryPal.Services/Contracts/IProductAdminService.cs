namespace FurryPal.Services.Contracts
{
    using Models;

    public interface IProductAdminService
    {
        void CreateProduct(string productCode, string name, string description, string categoryName,
            string manufacturerName, int stockQuantity);

        Product[] GetAllProducts();
    }
}