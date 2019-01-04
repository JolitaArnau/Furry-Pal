namespace FurryPal.Web.Controllers
{
    using AutoMapper;
    using FurryPal.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Data;
    using Services.Contracts;
    using Services.ShoppingCart;
    using ViewModels.Checkout;

    public class CheckoutController : BaseController
    {
        private ICheckoutService checkoutService { get; set; }
        private FurryPalDbContext dbContext { get; set; }
        private ShoppingCart shoppingCart { get; set; }

        public CheckoutController(UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper,
            ICheckoutService checkoutService, FurryPalDbContext dbContext, ShoppingCart shoppingCart) :
            base(userManager, signInManager, mapper)
        {
            this.dbContext = dbContext;
            this.checkoutService = checkoutService;
            this.shoppingCart = shoppingCart;
        }

        [HttpGet]
        public async Task<IActionResult> Buy(string id)
        {
            var user = await this.userManager.GetUserAsync(User);

            var userWithAddress = this.dbContext.Users
                .Where(u => u.Id.Equals(user.Id) && u.AddressId.Equals(user.AddressId))
                .Include(u => u.Address)
                .Include(p => p.Purchases)
                .ToList()
                .First();


            if (userWithAddress.Address.CityName != null &&
                userWithAddress.Address.CountryName != null && userWithAddress.Address.ZipCode != null &&
                userWithAddress.Address.StreetName != null && userWithAddress.Address.HouseNumber != 0)
            {
                await this.checkoutService.CreatePurchase(id, user.Id);

                var userCheckoutViewModel = mapper.Map<User, UserCheckoutBindingModel>(userWithAddress);

                //TODO: Implement a buy method which in the current context could set a boolean to true in the purchase model(requires db schema update)
                //TODO: Clear the cart only when the items are actually bought (when the 'bought' boolean is set to true)
                //TODO: Redirect to page where the user can see a successful message that all products were bought and he has no more money for beer!!!
                //this.shoppingCart.ClearCart();

                return await Task.Run(() => this.View(userCheckoutViewModel));
            }

            return LocalRedirect("/Identity/Account/Manage/AddressAndBillingInformation");
        }
    }
}