﻿using AutoMapper;
using FurryPal.Services.ShoppingCart;

namespace FurryPal.Web.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Common;
    using FurryPal.Models;
    using Data;

    public class HomeController : BaseController
    {

        public HomeController(UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper
        ) : base(
            userManager, signInManager, mapper)
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