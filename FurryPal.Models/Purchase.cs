namespace FurryPal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using Enums;
    
    public class Purchase
    {
        public Purchase()
        {
            this.Id = Guid.NewGuid().ToString();
            this.ProductPurchases = new List<ProductPurchase>();
        }
        
        public string Id { get; set; }

        public DateTime OrderDate { get; set; }
       
        public decimal TotalOrderPrice { get; set; }
         
        public PurchaseStatus Status { get; set; }
        
        public bool IsBought { get; set; }
        
        public ICollection<ProductPurchase> ProductPurchases { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }
    }
}