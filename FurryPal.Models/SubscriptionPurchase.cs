using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using FurryPal.Models.Common;
using FurryPal.Models.Enums;

namespace FurryPal.Models
{
    public class SubscriptionPurchase
    {
        public SubscriptionPurchase()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        
        public string Id { get; set; }

        [ForeignKey("User")]
        public string CustomerId { get; set; }
        public User Customer { get; set; }

        public DateTime InitialOrderDate { get; set; }

        public ReorderInterval ReorderInterval { get; set; }

        public DateTime NextReorderDispatchDate { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();

        [NotMapped]
        public decimal Discount => Products.Select(p => p.Price).Sum() * OrderDiscountConstants.SubscriptionDiscount;

        public decimal TotalOrderPrice { get; set; }
    }
}