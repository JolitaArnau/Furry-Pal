using System.Collections.Generic;
using FurryPal.Models;

namespace FurryPal.Services.Contracts
{
    public interface IShoppingCartService
    {
        Product[] PopulateCart(string productId);
    }
}