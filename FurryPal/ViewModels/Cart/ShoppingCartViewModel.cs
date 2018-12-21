using FurryPal.Services.ShoppingCart;

namespace FurryPal.Web.ViewModels.Cart
{
    public class ShoppingCartViewModel
    {
        public ShoppingCart ShoppingCart { get; set; }

        public decimal ShoppingCartTotal { get; set; }

    }
}