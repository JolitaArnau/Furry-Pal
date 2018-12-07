using System.Linq;
using FurryPal.Services.Contracts;

namespace FurryPal.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Data;
    using FurryPal.Models;
    using FurryPal.Web.Controllers;
    using Common;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = RoleConstants.Administrator)]
    [Area("Admin")]
    public class AdminBaseController : BaseController
    {
        private readonly IProductAdminService adminService;

        public AdminBaseController(UserManager<User> userManager, SignInManager<User> signInManager) : base(userManager,
            signInManager)
        {
        }

        public IActionResult Dashboard()
        {
            return this.View("Dashboard");
        }
    }
}