using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace FurryPal.Models
{
    public class User : IdentityUser<string>
    {
        public ICollection<Purchase> Purchases { get; set; }

        public ICollection<SubscriptionPurchase> SubscriptionPurchases { get; set; }

        [ForeignKey("Address")]
        public string AddressId { get; set; }
        public Address Address { get; set; }
    }
}