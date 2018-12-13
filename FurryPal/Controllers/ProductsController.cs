namespace FurryPal.Web.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using ViewModels.Products;
    using FurryPal.Models;
    using Services.Contracts;

    public class ProductsController : BaseController
    {
        private readonly IProductCustomerService productCustomerService;

        public ProductsController(UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper,
            IProductCustomerService productCustomerService) : base(userManager, signInManager, mapper)
        {
            this.productCustomerService = productCustomerService;
        }

        public async Task<IActionResult> Leashes()
        {
            var products = await this.productCustomerService.GetAllLeashes();

            var productsViewModel = mapper.Map<Product[], IEnumerable<ProductOverviewViewModel>>(products);

            return View("Leashes", productsViewModel);
        }
        
        public async Task<IActionResult> Toys()
        {
            var products = await this.productCustomerService.GetAllToys();

            var productsViewModel = mapper.Map<Product[], IEnumerable<ProductOverviewViewModel>>(products);

            return View("Toys", productsViewModel);
        }
        
        public async Task<IActionResult> Bowls()
        {
            var products = await this.productCustomerService.GetAllBowls();

            var productsViewModel = mapper.Map<Product[], IEnumerable<ProductOverviewViewModel>>(products);

            return View("Bowls", productsViewModel);
        }
        
        public async Task<IActionResult> Beds()
        {
            var products = await this.productCustomerService.GetAllBeds();

            var productsViewModel = mapper.Map<Product[], IEnumerable<ProductOverviewViewModel>>(products);

            return View("Beds", productsViewModel);
        } 
        
        public async Task<IActionResult> Food()
        {
            var products = await this.productCustomerService.GetAllFood();

            var productsViewModel = mapper.Map<Product[], IEnumerable<ProductOverviewViewModel>>(products);

            return View("Food", productsViewModel);
        }
        
        public async Task<IActionResult> Collars()
        {
            var products = await this.productCustomerService.GetAllCollars();

            var productsViewModel = mapper.Map<Product[], IEnumerable<ProductOverviewViewModel>>(products);

            return View("Collars", productsViewModel);
        }
        
        public async Task<IActionResult> Details(string id)
        {
            var product = this.productCustomerService.GetProductById(id);

            if (product == null)
            {
                return this.NotFound();
            }

            var model = this.mapper.Map<Product, ProductDetailViewModel>(product);

            return await Task.Run(() => this.View("Details", model));
        }
    }
}