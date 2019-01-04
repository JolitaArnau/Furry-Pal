using System.Threading.Tasks;
using FurryPal.Models;

namespace FurryPal.Services.Contracts
{
    public interface ICheckoutService
    {
        Task CreatePurchase(string shoppingCartId, string userId);
    }
}