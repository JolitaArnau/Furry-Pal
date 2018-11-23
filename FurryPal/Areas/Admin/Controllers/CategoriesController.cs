using System.Collections.Generic;
using AutoMapper;
using FurryPal.Data;
using FurryPal.Models;
using FurryPal.Services.Contracts;
using FurryPal.Web.ViewModels.Categories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FurryPal.Web.Areas.Admin.Controllers
{
    public class CategoriesController : AdminBaseController
    {
        private readonly IMapper mapper;
        private readonly ICategoryAdminService categoryAdminService;

        public CategoriesController(UserManager<User> userManager, SignInManager<User> signInManager,
            FurryPalDbContext dbContext, IMapper mapper, ICategoryAdminService categoryAdminService) : base(userManager,
            signInManager, dbContext)
        {
            this.mapper = mapper;
            this.categoryAdminService = categoryAdminService;
        }
        
        public IActionResult AllCategories()
        {
            var categories = categoryAdminService.GetAllCategories();

            var categoryViewModels = this.mapper.Map<Category[], IEnumerable<AllCategoriesViewModel>>(categories);

            return View("All", categoryViewModels);
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return this.View("Create");
        }

        [HttpPost]
        public IActionResult CreateCategory(CreateViewModel categoryCreateViewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View("Create", categoryCreateViewModel);
            }

            this.categoryAdminService.CreateCategory(categoryCreateViewModel.Name, categoryCreateViewModel.Description);

            return this.RedirectToAction("AllCategories", new {area = "Admin"});
        }
    }
}