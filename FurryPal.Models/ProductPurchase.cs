namespace FurryPal.Models
{
    public class ProductPurchase
    {
        public int Id { get; set; }
        
        public string ProductId { get; set; }
        public Product Product { get; set; }

        public string PurchaseId { get; set; }
        public Purchase Purchase { get; set; }
    }
}