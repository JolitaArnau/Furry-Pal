namespace FurryPal.Web.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Common;
    using FurryPal.Models;
    using Data;

    public class HomeController : BaseController
    {
        public HomeController(UserManager<User> userManager, SignInManager<User> signInManager,
            FurryPalDbContext dbContext) : base(userManager, signInManager, dbContext)
        {
        }

        public IActionResult Index()
        {
            var user = userManager.GetUserAsync(User).Result;

            if (signInManager.IsSignedIn(User) &&
                userManager.IsInRoleAsync(user, RoleConstants.Administrator).Result)
            {
                return this.RedirectToAction("Dashboard", "AdminBase", new {area = "Admin"});
            }

            return this.View();
        }
    }
}