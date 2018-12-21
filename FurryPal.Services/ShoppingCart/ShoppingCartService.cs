using System.Collections.Generic;
using System.Linq;
using FurryPal.Data;
using FurryPal.Models;

namespace FurryPal.Services.ShoppingCart
{
    using Contracts;

    public class ShoppingCartService : IShoppingCartService
    {
        private FurryPalDbContext dbContext { get; set; }

        public ShoppingCartService(FurryPalDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Product[] PopulateCart(string productId)
        {
            var product = this.dbContext.Products.FirstOrDefault(p => p.Id.Equals(productId));
            
            var products = new List<Product>();

            if (!products.Contains(product))
            {
                products.Add(product);
            }

            return products.ToArray();
        }
    }
}