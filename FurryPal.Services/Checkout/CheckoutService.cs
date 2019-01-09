using FurryPal.Models.Enums;
using Microsoft.EntityFrameworkCore.Internal;

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
        private readonly ShoppingCart.ShoppingCart cart;

        public CheckoutService(UserManager<User> userManager, FurryPalDbContext dbContext,
            ShoppingCart.ShoppingCart cart)
        {
            this.userManager = userManager;
            this.dbContext = dbContext;
            this.cart = cart;
        }

        public async Task CreatePurchase(string shoppingCartId, string userId)
        {
            var user = await this.dbContext.Users.FirstOrDefaultAsync(u => u.Id.Equals(userId));

            var userPurchase = user.Purchases.FirstOrDefault(p => p.OrderDate.Date.Equals(DateTime.Now.Date));

            if (userPurchase == null || userPurchase.IsBought)
            {
                var userShoppingCartItems = this.dbContext.ShoppingCartItems.Where(s =>
                    s.ShoppingCartId.Equals(shoppingCartId));

                var purchase = new Purchase
                {
                    OrderDate = DateTime.Now, User = user, UserId = userId, IsBought = false,
                    Status = PurchaseStatus.InProcess
                };

                foreach (var shoppingCartItem in userShoppingCartItems)
                {
                    var product = shoppingCartItem.Product =
                        this.dbContext.Products.FirstOrDefaultAsync(p => p.Id.Equals(shoppingCartItem.ProductId))
                            .Result;

                    var productPurchase = new ProductPurchase()
                    {
                        PurchaseId = purchase.Id,
                        Purchase = purchase,
                        ProductId = product.Id,
                        Product = product,
                    };

                    this.dbContext.ProductsPurchases.Add(productPurchase);

                    purchase.TotalOrderPrice += shoppingCartItem.Product.Price * shoppingCartItem.Quantity;

                    product.StockQuantity--;
                }

                this.cart.ClearCart();
            }
            else
            {
                var userShoppingCartItems = this.dbContext.ShoppingCartItems.Where(s =>
                    s.ShoppingCartId.Equals(shoppingCartId));

                foreach (var shoppingCartItem in userShoppingCartItems)
                {
                    var product = shoppingCartItem.Product =
                        this.dbContext.Products.FirstOrDefaultAsync(p => p.Id.Equals(shoppingCartItem.ProductId))
                            .Result;

                    if (!userPurchase.ProductPurchases.Any(p => p.ProductId.Equals(product.Id)))
                    {
                        var productPurchase = new ProductPurchase()
                        {
                            PurchaseId = userPurchase.Id,
                            Purchase = userPurchase,
                            ProductId = product.Id,
                            Product = product,
                        };

                        this.dbContext.ProductsPurchases.Add(productPurchase);

                        userPurchase.TotalOrderPrice += shoppingCartItem.Product.Price * shoppingCartItem.Quantity;

                        product.StockQuantity--;
                    }
                }
            }

            await this.dbContext.SaveChangesAsync();
        }

        public async Task ThankYou(string userId)
        {
            var user = await this.dbContext.Users.FirstOrDefaultAsync(u => u.Id.Equals(userId));

            if (user.Purchases.Last() != null) user.Purchases.Last().IsBought = true;

            await this.dbContext.SaveChangesAsync();
        }
    }
}