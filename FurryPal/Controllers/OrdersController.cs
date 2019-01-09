using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FurryPal.Data;
using FurryPal.Models;
using FurryPal.Web.ViewModels.Orders;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FurryPal.Web.Controllers
{
    public class OrdersController : BaseController
    {
        private FurryPalDbContext dbContext { get; set; }

        public OrdersController(UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper,
            FurryPalDbContext dbContext) :
            base(userManager, signInManager, mapper)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> YourOrders()
        {
            var user = await this.userManager.GetUserAsync(User);

            var purchases = this.dbContext.Purchases
                .Where(p => p.UserId.Equals(user.Id) && p.IsBought)
                .Include(p => p.ProductPurchases)
                .ThenInclude(p => p.Product)
                .ToArray();

            var userCheckoutViewModel =
                this.mapper.Map<Purchase[], IEnumerable<YourOrdersViewModel>>(purchases);

            return await Task.Run(() => this.View(userCheckoutViewModel));
        }
    }
}