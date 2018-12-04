using AutoMapper;
namespace FurryPal.Web.Areas.Admin.Controllers
{
    using System.Collections.Generic;
    using FurryPal.Models;
    using FurryPal.Services.Contracts;
    using FurryPal.Web.Areas.Admin.ViewModels.Users;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class UsersController : AdminBaseController
    {
        private readonly IUserAdminService userAdminService;
        private readonly IMapper mapper;

        public UsersController(UserManager<User> userManager, SignInManager<User> signInManager,
            IUserAdminService userAdminService, IMapper mapper) : base(userManager,
            signInManager)
        {
            this.userAdminService = userAdminService;
            this.mapper = mapper;
        }

        public IActionResult All()
        {
            var users = this.userAdminService.GetAllUsers();
            var userViewModels = this.mapper.Map<List<UserViewModel>>(users);
            this.ViewData["Users"] = userViewModels;
            return this.View();
        }

        [HttpPost]
        public IActionResult PromoteUser(UserViewModel model)
        {
            this.userAdminService.PromoteUser(model.Id);
            return this.RedirectToAction("All", "Users");
        }

        [HttpPost]
        public IActionResult DemoteUser(UserViewModel model)
        {
            this.userAdminService.DemoteUser(model.Id);
            return this.RedirectToAction("All", "Users");
        }
    }
}