namespace FurryPal.Models
{
    public class ProductReview
    {
        public int Id { get; set; }

        public string ProductId { get; set; }
        public Product Product { get; set; }

        public string ReviewId { get; set; }
        public Review Review { get; set; }
    }
}