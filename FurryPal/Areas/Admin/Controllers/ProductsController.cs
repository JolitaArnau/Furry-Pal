using AutoMapper;

namespace FurryPal.Web.Areas.Admin.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Services.Contracts;
    using FurryPal.Models;
    using ViewModels.Products;
    using Common;

    public class ProductsController : AdminBaseController
    {
        private readonly IProductAdminService productAdminService;
        private readonly IMapper mapper;

        public ProductsController(UserManager<User> userManager, SignInManager<User> signInManager,
            IProductAdminService productAdminService, IMapper mapper) : base(userManager, signInManager)
        {
            this.productAdminService = productAdminService;
            this.mapper = mapper;
        }

        public async Task<IActionResult> AllProducts()
        {
            var products = await this.productAdminService.GetAllProductsAsync();

            var productsViewModel = this.mapper.Map<Product[], IEnumerable<AllProductsViewModel>>(products);

            return View("All", productsViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            var model = new ProductBindingModel(GetCategories(), GetManufacturers());

            return await Task.Run(() => this.View("Create", model));
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductBindingModel createProductViewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return await Task.Run(() => this.View("Create", createProductViewModel));
            }

            if (this.productAdminService.ProductExistsAsync(createProductViewModel.Name).Result)
            {
                this.ModelState.AddModelError("",
                    string.Format(ErrorMessages.ProductAlreadyExists, createProductViewModel.Name));
                return await Task.Run(() => this.View("Create", createProductViewModel));
            }

            await this.productAdminService.CreateProductAsync(createProductViewModel.ProductCode,
                createProductViewModel.Name, createProductViewModel.Description, createProductViewModel.Category,
                createProductViewModel.Manufacturer, createProductViewModel.Price,
                createProductViewModel.StockQuantity, createProductViewModel.ImageUrl, createProductViewModel.Keywords);

            return this.RedirectToAction("AllProducts");
        }

        [HttpGet]
        public async Task<IActionResult> EditProduct(string id)
        {
            var product = this.productAdminService.GetProductByIdAsync(id).Result;

            if (product == null)
            {
                return this.NotFound();
            }

            var model = this.mapper.Map<Product, ProductBindingModel>(product);

            return await Task.Run(() => this.View("Edit", model));
        }

        [HttpPost]
        public async Task<IActionResult> EditProduct(ProductBindingModel model)
        {
            await this.productAdminService.EditProductAsync(model.Id, model.ProductCode, model.Name, model.Description,
                model.Price, model.StockQuantity);

            return this.RedirectToAction("AllProducts");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            var product = this.productAdminService.GetProductByIdAsync(id).Result;

            if (product == null)
            {
                return this.NotFound();
            }

            var model = this.mapper.Map<Product, ProductBindingModel>(product);

            return await Task.Run(() => this.View("Delete", model));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProduct(ProductBindingModel model)
        {
            await this.productAdminService.DeleteProductAsync(model.Id);

            return this.RedirectToAction("AllProducts");
        }

        public List<SelectListItem> GetCategories()
        {
            var categories = this.productAdminService.GetCategories();

            return categories;
        }

        public List<SelectListItem> GetManufacturers()
        {
            var manufacturers = this.productAdminService.GetManufacturers();

            return manufacturers;
        }
    }
}