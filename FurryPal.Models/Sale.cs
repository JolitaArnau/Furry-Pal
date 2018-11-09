using System;
using System.Collections.Generic;

namespace FurryPal.Models
{
    public class Sale
    {
        public Guid Id { get; set; }

        public string Type { get; set; }

        public ICollection<Product> ProductsOnSale { get; set; } = new HashSet<Product>();
    }
}