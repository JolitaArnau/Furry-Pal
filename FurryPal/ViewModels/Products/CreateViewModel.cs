using System.Collections.Generic;
using FurryPal.Models;

namespace FurryPal.Web.ViewModels.Products
{
    using System;
    using System.ComponentModel.DataAnnotations;
    
    public class CreateViewModel
    {
        [Required]
        [RegularExpression(@"(#[\d+]+)(\w+)", ErrorMessage =
            "The product code should start with a #, followed by the article code, coming from the manufacturer and the product name itself.")]
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
        public ICollection<Category> Categories { get; set; }

        [Required]
        [Range(1, Double.MaxValue)]
        public decimal Price { get; set; }

        [Display(Name = "Select a manufacturer")]
        public ICollection<Manufacturer> Manufacturers { get; set; }

        [Required]
        [Range(1, Int32.MaxValue)]
        public int StockQuantity { get; set; }
    }
}