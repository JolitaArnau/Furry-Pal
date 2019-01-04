using FurryPal.Common;
using FurryPal.Services.ShoppingCart;
using FurryPal.Web.ViewModels.Cart;
using Microsoft.AspNetCore.Authorization;


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

        public async Task<IActionResult> Order()
        {
            var items = shoppingCart.GetShoppingCartItems();
            shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel()
            {
                ShoppingCart = shoppingCart,
                ShoppingCartTotal = shoppingCart.GetShoppingCartTotal()
            };

            return await Task.Run(() => View("Order", shoppingCartViewModel));
        }

        [Authorize(Roles = RoleConstants.User)]
        public async Task<IActionResult> Add(string id)
        {
            var productToAdd = this.productService.GetProductById(id);

            if (productToAdd != null)
            {
                shoppingCart.AddToCart(productToAdd, 1);
            }

            return await Task.Run(() => RedirectToAction("Order"));
        }

        public async Task<IActionResult> Remove(string id)
        {
            var productToRemove = this.productService.GetProductById(id);
            if (productToRemove != null)
            {
                shoppingCart.RemoveFromCart(productToRemove);
            }
            shoppingCart.ClearCart();

            return await Task.Run(() => RedirectToAction("Order"));
        }

        public async Task<IActionResult> RemoveAll()
        {            
            shoppingCart.ClearCart();

            return await Task.Run(() => RedirectToAction("Order"));
        }

        public async Task<IActionResult> Checkout(string id)
        {
            return await Task.Run(() => this.RedirectToAction("Buy", "Checkout", new {id}));
        }
    }
}