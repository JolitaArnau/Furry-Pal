using AutoMapper;

namespace FurryPal.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using FurryPal.Models;
    using FurryPal.Web.Controllers;
    using Common;
    using Services.Contracts;


    [Authorize(Roles = RoleConstants.Administrator)]
    [Area("Admin")]
    public class AdminBaseController : Controller
    {

        protected UserManager<User> userManager;
        protected SignInManager<User> signInManager;
        protected IMapper mapper;
        
        
        public AdminBaseController(UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.mapper = mapper;
        }

        public IActionResult Dashboard()
        {
            return this.View("Dashboard");
        }
    }
}