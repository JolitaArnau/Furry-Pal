using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FurryPal.Data;
using FurryPal.Models;
using FurryPal.Web.Areas.Admin.ViewModels.Products;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FurryPal.Web.Areas.Admin.Controllers
{
    public class ProductsController : AdminBaseController
    {
        private readonly FurryPalDbContext db;

        public ProductsController(UserManager<User> userManager, SignInManager<User> signInManager,
            FurryPalDbContext db) : base(userManager, signInManager)
        {
            this.db = db;
        }

        public Task<Product[]> AllProducts()
        {
            throw new System.NotImplementedException();
        }

        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            var model = new CreateViewModel(GetCategories());

            return await Task.Run(() => this.View("Create", model));
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(string productCode, string name, string description,
            string categoryName,
            string manufacturerName, int stockQuantity)
        {
            throw new System.NotImplementedException();
        }

        public List<SelectListItem> GetCategories()
        {
            var dbCategories = new List<Category>(db.Categories);

            var listItems = new List<SelectListItem>();

            foreach (var category in dbCategories)
            {
                var selectListItem = new SelectListItem {Value = category.Id, Text = category.Name};

                listItems.Add(selectListItem);
            }

            return listItems;
        }
    }
}