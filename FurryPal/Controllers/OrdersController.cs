using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FurryPal.Data;
using FurryPal.Models;
using FurryPal.Web.ViewModels.Checkout;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FurryPal.Web.Controllers
{
    public class OrdersController : BaseController
    {
        private FurryPalDbContext dbContext { get; set; }
        
        public OrdersController(UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper,  FurryPalDbContext dbContext) :
            base(userManager, signInManager, mapper)
        {
            this.dbContext = dbContext;
        }
        
        [HttpGet]
        public async Task<IActionResult> YourOrders()
        {
            var userId = this.userManager.GetUserAsync(User).Result.Id;

            var user = this.dbContext.Users
                .Include(p => p.Purchases)
                .ToList()
                .FirstOrDefault(u => u.Id.Equals(userId));
            
            
            var userCheckoutViewModel = mapper.Map<User, UserTryCheckOutBindingModel>(user);
            return await Task.Run(() => this.View(userCheckoutViewModel));       
        }
    }
}