using System.ComponentModel;
using System.Security.Policy;

namespace FurryPal.Web.Areas.Admin.ViewModels.Products
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class ProductBindingModel
    {
        public ProductBindingModel()
        {
        }

        public ProductBindingModel(List<SelectListItem> categories, List<SelectListItem> manufacturers)
        {
            this.Categories = new List<SelectListItem>(categories);
            this.Manufacturers = new List<SelectListItem>(manufacturers);
        }

        public string Id { get; set; }

        [Required]
        [RegularExpression(@"(#[\d+]+)(\w+)", ErrorMessage =
            "The product code should start with a #, followed by the article code, coming from the manufacturer and the product name itself.")]
        [Display(Name = "Product Code")]
        public string ProductCode { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Product Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Product Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Select a category")]
        public string Category { get; set; }

        [Required]
        [Display(Name = "Select a manufacturer")]
        public string Manufacturer { get; set; }

        public List<SelectListItem> Categories { get; }

        public List<SelectListItem> Manufacturers { get; }

        [Required]
        [Display(Name = "Enter Keywords")]
        [Description(
            "Enter keywords, separated with a comma, followed by a whitespace. Example: bed, beds, food, dry food, treats")]
        public string Keywords { get; set; }

        [Required] [Range(1, Double.MaxValue)] public decimal Price { get; set; }

        [Required] [Range(1, Int32.MaxValue)] public int StockQuantity { get; set; }

        [DataType(DataType.ImageUrl)] public string ImageUrl { get; set; }
    }
}