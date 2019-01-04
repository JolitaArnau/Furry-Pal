namespace FurryPal.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class ShoppingCartItem
    {
        public int Id { get; set; }

        public string ProductId { get; set; }
        public Product Product { get; set; }

        public int Quantity  { get; set; }

        public string ShoppingCartId  { get; set; }
    }
}