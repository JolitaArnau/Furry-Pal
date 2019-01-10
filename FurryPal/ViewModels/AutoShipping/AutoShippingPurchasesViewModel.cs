using System;
using System.Collections.Generic;
using FurryPal.Models;

namespace FurryPal.Web.ViewModels.AutoShipping
{
    public class AutoShippingPurchasesViewModel
    {
        public DateTime NextReorderDispatchDate { get; set; }

        public decimal TotalOrderPrice { get; set; }
        
        public List<ProductPurchase> ProductPurchases { get; set; }
    }
}