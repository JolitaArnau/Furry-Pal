using FurryPal.Services.ShoppingCart;
using FurryPal.Web.ViewModels.Cart;


namespace FurryPal.Web.Controllers
{
    using System.Threading.Tasks;
    using AutoMapper;
    using FurryPal.Models;
    using Services.Contracts;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class ShoppingCartController : BaseController
    {
        private readonly ShoppingCart shoppingCart;
        private readonly IProductCustomerService productService;

        public ShoppingCartController(UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper,
            ShoppingCart shoppingCart, IProductCustomerService productService
        ) : base(userManager, signInManager, mapper)
        {
            this.shoppingCart = shoppingCart;
            this.productService = productService;
        }

        public async Task<IActionResult> Cart()
        {
            var items = shoppingCart.GetShoppingCartItems();
            shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel()
            {
                ShoppingCart = shoppingCart,
                ShoppingCartTotal = shoppingCart.GetShoppingCartTotal()
            };

            return await Task.Run(() => View("Cart", shoppingCartViewModel));
        }

        public async Task<IActionResult> Add(string id)
        {
            var productToAdd = this.productService.GetProductById(id);

            if (productToAdd != null)
            {
                shoppingCart.AddToCart(productToAdd, 1);
            }

            return await Task.Run(() => RedirectToAction("Cart"));
        }

        public async Task<IActionResult> Remove(string id)
        {
            var productToRemove = this.productService.GetProductById(id);

            if (productToRemove != null)
            {
                shoppingCart.RemoveFromCart(productToRemove);
            }

            return await Task.Run(() => View("Cart"));
        }
    }
}