namespace FurryPal.Web.Areas.Admin.ViewModels.Products
{
    public class AllProductsViewModel
    {
        public string Id { get; set; }
        
        public string ProductCode { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string CategoryName { get; set; }

        public string ManufacturerName { get; set; }

        public decimal Price { get; set; }

        public int StockQuantity { get; set; }

        public string ImageUrl { get; set; }
    }
}