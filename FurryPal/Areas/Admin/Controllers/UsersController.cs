namespace FurryPal.Web.Areas.Admin.Controllers
{
    using System.Collections.Generic;
    using FurryPal.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using AutoMapper;
    using Services.Contracts;
    using ViewModels.Users;

    public class UsersController : AdminBaseController
    {
        private readonly IUserAdminService userAdminService;

        public UsersController(UserManager<User> userManager, SignInManager<User> signInManager,
            IUserAdminService userAdminService, IMapper mapper) : base(userManager,
            signInManager, mapper)
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