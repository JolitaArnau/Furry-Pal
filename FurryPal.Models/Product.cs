using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FurryPal.Models
{
    public class Product
    {
        public Product()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        
        public string Id { get; set; }
        
        public string ProductCode { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [ForeignKey("Product")]
        public string CategoryId { get; set; }
        public Category Category { get; set; }

        public decimal Price { get; set; }

        [ForeignKey("Manufacturer")]
        public string ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }

        public int StockQuantity { get; set; }
    }
}