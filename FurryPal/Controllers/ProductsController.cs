using System.Collections.Generic;
using System.Threading.Tasks;
using FurryPal.Web.ViewModels.Products;
using Microsoft.AspNetCore.Mvc;

namespace FurryPal.Web.Controllers
{
    using AutoMapper;
    using FurryPal.Models;
    using Services.Contracts;
    using Microsoft.AspNetCore.Identity;
    
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

            var productsViewModel = mapper.Map<Product[], IEnumerable<AllProductsByCategoryViewModel>>(products);

            return View("Leashes", productsViewModel);
        }
    }
}