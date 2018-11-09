using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using FurryPal.Models.Enums;

namespace FurryPal.Models
{
    public class Purchase
    {
        public Guid Id { get; set; }
        
        [ForeignKey("User")]
        public Guid CustomerId { get; set; }
        public User Customer { get; set; }

        public DateTime OrderDate { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();

        public decimal TotalOrderPrice { get; set; }
         
        public PurchaseStatus Status { get; set; }
    }
}