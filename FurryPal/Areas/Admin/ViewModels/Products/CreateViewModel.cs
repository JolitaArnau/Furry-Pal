using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FurryPal.Web.Areas.Admin.ViewModels.Products
{
    public class CreateViewModel
    {
        public CreateViewModel(List<SelectListItem> items)
        {
            this.Categories = new List<SelectListItem>(items);
        }
        
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

        public List<SelectListItem> Categories { get; set; }

//        [Display(Name = "Select a manufacturer")]
//        public IEnumerable<SelectListItem> Manufacturers { get; set; }

        [Required] [Range(1, Double.MaxValue)] public decimal Price { get; set; }

        [Required] [Range(1, Int32.MaxValue)] public int StockQuantity { get; set; }
    }
}