namespace FurryPal.Models
{
    using System;
    using System.Collections.Generic;
    
    public class Sale
    {
        public Sale()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<Product> ProductsOnSale { get; set; } = new HashSet<Product>();
    }
}