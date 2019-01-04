namespace FurryPal.Services.Checkout
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Data;
    using Models;
    using Contracts;

    public class CheckoutService : ICheckoutService
    {
        private UserManager<User> userManager { get; set; }
        private readonly FurryPalDbContext dbContext;

        public CheckoutService(UserManager<User> userManager, FurryPalDbContext dbContext)
        {
            this.userManager = userManager;
            this.dbContext = dbContext;
        }

        public async Task CreatePurchase(string shoppingCartId, string userId)
        {
            var user = this.dbContext.Users.FirstOrDefaultAsync(u => u.Id.Equals(userId)).Result;

            // TODO: users should be able to add products to their current purchase without creating a new purchase object 

            var userShoppingCartItems = this.dbContext.ShoppingCartItems.Where(s =>
                s.ShoppingCartId.Equals(shoppingCartId));

            var purchase = new Purchase {OrderDate = DateTime.Now, Customer = user, CustomerId = userId};


            foreach (var shoppingCartItem in userShoppingCartItems)
            {
                var product = shoppingCartItem.Product =
                    this.dbContext.Products.FirstOrDefaultAsync(p => p.Id.Equals(shoppingCartItem.ProductId))
                        .Result;

                purchase.TotalOrderPrice += shoppingCartItem.Product.Price * shoppingCartItem.Quantity;

                purchase.Products.Add(product);
            }

            user.Purchases.Add(purchase);

            await this.dbContext.SaveChangesAsync();
        }
    }
}