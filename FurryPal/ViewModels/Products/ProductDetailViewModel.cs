namespace FurryPal.Web.ViewModels.Products
{
    public class ProductDetailViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public string ManufacturerName { get; set; }

        public decimal Price { get; set; }

        public int StockQuantity { get; set; }

        public bool IsAvailableForAutoShipping { get; set; }
    }
}