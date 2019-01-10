using FurryPal.Web.ViewModels.AutoShipping;

namespace FurryPal.Web.Controllers
{
    using System.Linq;
    using AutoMapper;
    using FurryPal.Models;
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Data;
    using ViewModels.Orders;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    public class AutoShippingPurchasesController : BaseController
    {
        //TODO: extract service!! 

        private readonly FurryPalDbContext db;

        public AutoShippingPurchasesController(UserManager<User> userManager, SignInManager<User> signInManager,
            IMapper mapper, FurryPalDbContext db) : base(userManager, signInManager, mapper)
        {
            this.db = db;
        }

        [HttpGet]
        public async Task<IActionResult> Orders()
        {
            var user = await this.userManager.GetUserAsync(User);
            
            var autoShippingPurchases = this.db.SubscribedPurchases
                .Where(p => p.CustomerId.Equals(user.Id))
                .Include(p => p.ProductPurchases)
                .ThenInclude(p => p.Product)
                .ToArray();

            var autoShippingPurchasesViewModel =
                this.mapper.Map<AutoShippingPurchase[], IEnumerable<AutoShippingPurchasesViewModel>>(autoShippingPurchases);
            
            return await Task.Run(() => this.View(autoShippingPurchasesViewModel));
        }

        [HttpPost]
        public async Task<IActionResult> Orders(string id)
        {
            var user = await this.userManager.GetUserAsync(User);

            var product = await this.db.Products.FirstOrDefaultAsync(p => p.Id.Equals(id));

            var purchase = new Purchase
            {
                OrderDate = DateTime.Now, User = user, UserId = user.Id, IsBought = false
            };
            
            var productPurchase = new ProductPurchase()
            {
                PurchaseId = purchase.Id,
                Purchase = purchase,
                ProductId = product.Id,
                Product = product,
            };
            
            this.db.ProductsPurchases.Add(productPurchase);

            purchase.TotalOrderPrice = productPurchase.Product.Price;
            
            var autoShippingPurchase = new AutoShippingPurchase()
            {
                InitialOrderDate = purchase.OrderDate,
                CustomerId = user.Id,
                Customer = user
            };

            autoShippingPurchase.NextReorderDispatchDate = autoShippingPurchase.InitialOrderDate.AddDays(31);
            
            autoShippingPurchase.ProductPurchases.Add
                (productPurchase);

            autoShippingPurchase.TotalOrderPrice = product.Price;

            this.db.SubscribedPurchases.Add(autoShippingPurchase);

            await this.db.SaveChangesAsync();

            return await Task.Run(() => this.RedirectToAction("Orders"));
        }
    }
}