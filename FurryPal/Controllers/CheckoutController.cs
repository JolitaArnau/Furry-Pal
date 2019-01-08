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
                var userCheckoutViewModel = mapper.Map<User, UserTryCheckOutBindingModel>(userWithAddress);
                this.shoppingCart.ClearCart();
                return await Task.Run(() => this.View(userCheckoutViewModel));
            }

            return LocalRedirect("/Identity/Account/Manage/AddressAndBillingInformation");
        }

        [HttpGet]
        public async Task<IActionResult> ThankYou()
        {
            var user = await this.userManager.GetUserAsync(User);

            var userWithPurchase = this.dbContext.Users
                .Where(u => u.Id.Equals(user.Id))
                .Include(p => p.Purchases)
                .ToList()
                .First();

            await this.checkoutService.ThankYou(userWithPurchase.Id);

            this.shoppingCart.ClearCart();

            return await Task.Run(() => this.View());
        }
    }
}