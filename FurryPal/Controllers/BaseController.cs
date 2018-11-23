using FurryPal.Data;
using FurryPal.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FurryPal.Web.Controllers
{
    public class BaseController : Controller
    {
        protected readonly UserManager<User> userManager;
        protected readonly SignInManager<User> signInManager;
        protected readonly FurryPalDbContext dbContext;

        public BaseController(UserManager<User> userManager, SignInManager<User> signInManager,
            FurryPalDbContext dbContext)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.dbContext = dbContext;
        }
    }
}