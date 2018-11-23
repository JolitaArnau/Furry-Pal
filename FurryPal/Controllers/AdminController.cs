using AutoMapper;

namespace FurryPal.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using Common;
    using Data;
    using FurryPal.Models;
    using Services.Contracts;
    using ViewModels.Categories;


    [Authorize(Roles = RoleConstants.Administrator)]
    public class AdminController : BaseController
    {
        private readonly ICategoryAdminService categoryAdminService;
        private readonly IMapper mapper;

        public AdminController(UserManager<User> userManager, SignInManager<User> signInManager,
            FurryPalDbContext dbContext, ICategoryAdminService categoryAdminService, IMapper mapper
        ) : base(userManager, signInManager, dbContext)
        {
            this.categoryAdminService = categoryAdminService;
            this.mapper = mapper;
        }

        public IActionResult Dashboard()
        {
            return View("Home/Dashboard");
        }

        public IActionResult AllCategories()
        {
            var categories = categoryAdminService.GetAllCategories();

            var categoryViewModels = this.mapper.Map<Category[], IEnumerable<AllCategoriesViewModel>>(categories);

            return View("Categories/All", categoryViewModels);
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return this.View("Categories/Create");
        }

        [HttpPost]
        public IActionResult CreateCategory(CreateViewModel categoryCreateViewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View("Categories/Create", categoryCreateViewModel);
            }

            this.categoryAdminService.CreateCategory(categoryCreateViewModel.Name, categoryCreateViewModel.Description);

            return this.RedirectToAction("AllCategories", "Admin");
        }
    }
}