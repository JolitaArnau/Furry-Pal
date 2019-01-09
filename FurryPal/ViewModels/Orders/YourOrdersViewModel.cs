using System;
using System.Collections.Generic;
using FurryPal.Models;

namespace FurryPal.Web.ViewModels.Orders
{
    public class YourOrdersViewModel
    {
        public bool IsBought { get; set; }
        
        public DateTime OrderDate { get; set; }

        public decimal TotalOrderPrice { get; set; }
        
        public List<ProductPurchase> ProductPurchases { get; set; }

    }
}