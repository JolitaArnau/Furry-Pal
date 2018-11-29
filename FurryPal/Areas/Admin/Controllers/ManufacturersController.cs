using AutoMapper;

namespace FurryPal.Web.Areas.Admin.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Common;
    using Data;
    using FurryPal.Models;
    using Services.Contracts;
    using ViewModels.Manufacturers;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using CreateViewModel = ViewModels.Manufacturers.CreateViewModel;
    
    public class ManufacturersController : AdminBaseController
    {
        private readonly IMapper mapper;
        private readonly IManufacturerAdminService manufacturerAdminService;

        public ManufacturersController(UserManager<User> userManager, SignInManager<User> signInManager,
            FurryPalDbContext dbContext, IMapper mapper, IManufacturerAdminService manufacturerAdminService) : base(
            userManager, signInManager, dbContext)
        {
            this.mapper = mapper;
            this.manufacturerAdminService = manufacturerAdminService;
        }

        public IActionResult AllManufacturers()
        {
            var manufacturers = manufacturerAdminService.GetAllManufacturersAsync().Result;

            var categoryViewModels =
                this.mapper.Map<Manufacturer[], IEnumerable<AllManufacturersViewModel>>(manufacturers);

            return View("All", categoryViewModels);
        }

        [HttpGet]
        public async Task<IActionResult> CreateManufacturer()
        {
            return await Task.Run(() => this.View("Create"));
        }

        [HttpPost]
        public  async Task<IActionResult>  CreateManufacturer(CreateViewModel createViewModel)
        {
            if (!this.ModelState.IsValid ||
                this.manufacturerAdminService.ManufacturerExistsAsync(createViewModel.Name).Result)
            {
                this.ModelState.AddModelError("",
                    string.Format(ErrorMessages.CategoryAlreadyExists, createViewModel.Name));
                return this.View("Create", createViewModel);
            }

            await this.manufacturerAdminService.CreateManufacturerAsync(createViewModel.Name, createViewModel.Email,
                createViewModel.PhoneNumber);


            return this.RedirectToAction("AllManufacturers");
        }
        
        [HttpGet]
        public async Task<IActionResult> EditManufacturer(string id)
        {
            var manufacturer = this.manufacturerAdminService.GetManufacturerByIdAsync(id).Result;
            
            if (manufacturer == null)
            {
                return this.NotFound();
            }
                    
            var editDeleteViewModel = this.mapper.Map<Manufacturer, EditDeleteManufacturerViewModel>(manufacturer);
    
            return await Task.Run(() => this.View("Edit", editDeleteViewModel));
        }
        
        [HttpPost]
        public async Task<IActionResult> EditManufacturer(EditDeleteManufacturerViewModel editDeleteViewModel)
        {
            await this.manufacturerAdminService.EditManufacturerAsync(editDeleteViewModel.Id, editDeleteViewModel.Name,
                editDeleteViewModel.Email, editDeleteViewModel.PhoneNumber);

            return this.RedirectToAction("AllManufacturers");
        }
        
        [HttpGet]
        public async Task<IActionResult> DeleteManufacturer(string id)
        {
            var category = this.manufacturerAdminService.GetManufacturerByIdAsync(id).Result;
            
            if (category == null)
            {
                return this.NotFound();
            }
                    
            var editDeleteViewModel = this.mapper.Map<Manufacturer, EditDeleteManufacturerViewModel>(category);
    
            return await Task.Run(() => this.View("Delete", editDeleteViewModel));
        }
        
        [HttpPost]
        public async Task<IActionResult> DeleteManufacturer(EditDeleteManufacturerViewModel editDeleteViewModel)
        {
            await this.manufacturerAdminService.DeleteManufacturerAsync(editDeleteViewModel.Id);

            return this.RedirectToAction("AllManufacturers");
        }

    }
}