namespace FurryPal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Common;
    using Enums;

    public class AutoShippingPurchase
    {
        public AutoShippingPurchase()
        {
            this.Id = Guid.NewGuid().ToString();
            this.ProductPurchases = new List<ProductPurchase>();
        }
        
        public string Id { get; set; }
      
        public DateTime InitialOrderDate { get; set; }

        public ReorderInterval ReorderInterval { get; set; }

        public DateTime NextReorderDispatchDate { get; set; }

        public ICollection<ProductPurchase> ProductPurchases { get; set; }

        public decimal TotalOrderPrice { get; set; }
        
        [ForeignKey("User")]
        public string CustomerId { get; set; }
        public User Customer { get; set; }

    }
}