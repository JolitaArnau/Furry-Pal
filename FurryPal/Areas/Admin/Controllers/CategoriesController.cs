using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FurryPal.Common;
using FurryPal.Data;
using FurryPal.Models;
using FurryPal.Services.Contracts;
using FurryPal.Web.Areas.Admin.ViewModels.Categories;
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

        public async Task<IActionResult> AllCategories()
        {
            var categories = await this.categoryAdminService.GetAllCategoriesAsync();

            var categoryViewModels = this.mapper.Map<Category[], IEnumerable<AllCategoriesViewModel>>(categories);

            return View("All", categoryViewModels);
        }

        [HttpGet]
        public async Task<IActionResult> CreateCategory()
        {
            return await Task.Run(() => this.View("Create"));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateViewModel categoryCreateViewModel)
        {
            if (!this.ModelState.IsValid ||
                categoryAdminService.CategoryExistsAsync(categoryCreateViewModel.Name).Result)
            {
                
                this.ModelState.AddModelError("", string.Format(ErrorMessages.CategoryAlreadyExists, categoryCreateViewModel.Name));
                return await Task.Run(() => this.View("Create", categoryCreateViewModel));
            }

            await this.categoryAdminService.CreateCategoryAsync(categoryCreateViewModel.Name,
                categoryCreateViewModel.Description);

            return this.RedirectToAction("AllCategories");
        }
        
        [HttpGet]
        public async Task<IActionResult> EditCategory(string id)
        {
            var category = this.categoryAdminService.GetCategoryByIdAsync(id).Result;
            
            if (category == null)
            {
                return this.NotFound();
            }
                    
            var editDeleteViewModel = this.mapper.Map<Category, EditDeleteCategoryViewModel>(category);
    
            return await Task.Run(() => this.View("Edit", editDeleteViewModel));
        }
        
        [HttpPost]
        public async Task<IActionResult> EditCategory(EditDeleteCategoryViewModel editDeleteCategoryViewModel)
        {
           await this.categoryAdminService.EditCategoryAsync(editDeleteCategoryViewModel.Id, editDeleteCategoryViewModel.Name,
                editDeleteCategoryViewModel.Description);

            return this.RedirectToAction("AllCategories");
        }
        
        [HttpGet]
        public async Task<IActionResult> DeleteCategory(string id)
        {
            var category = this.categoryAdminService.GetCategoryByIdAsync(id).Result;
            
            if (category == null)
            {
                return this.NotFound();
            }
                    
            var editDeleteViewModel = this.mapper.Map<Category, EditDeleteCategoryViewModel>(category);
    
            return await Task.Run(() => this.View("Delete", editDeleteViewModel));
        }
        
        [HttpPost]
        public async Task<IActionResult> DeleteCategory(EditDeleteCategoryViewModel editDeleteCategoryViewModel)
        {
            await this.categoryAdminService.DeleteCategoryAsync(editDeleteCategoryViewModel.Id);

            return this.RedirectToAction("AllCategories");
        }
    }
}