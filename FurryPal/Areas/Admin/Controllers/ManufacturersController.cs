using System.Collections.Generic;
using AutoMapper;
using FurryPal.Data;
using FurryPal.Models;
using FurryPal.Services.Contracts;
using FurryPal.Web.Areas.Admin.ViewModels.Manufacturers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using CreateViewModel = FurryPal.Web.Areas.Admin.ViewModels.Manufacturers.CreateViewModel;

namespace FurryPal.Web.Areas.Admin.Controllers
{
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
            var manufacturers = manufacturerAdminService.GetAllManufacturers();

            var categoryViewModels = this.mapper.Map<Manufacturer[], IEnumerable<AllManufacturersViewModel>>(manufacturers);

            return View("All", categoryViewModels);
        }

        [HttpGet]
        public IActionResult CreateManufacturer()
        {
            return this.View("Create");
        }

        [HttpPost]
        public IActionResult CreateManufacturer(CreateViewModel categoryCreateViewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View("Create", categoryCreateViewModel);
            }

            this.manufacturerAdminService.CreateManufacturer(categoryCreateViewModel.Name,
                categoryCreateViewModel.Email, categoryCreateViewModel.PhoneNumber);

            return this.RedirectToAction("AllManufacturers", new {area = "Admin"});
        }
    }
}