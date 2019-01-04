namespace FurryPal.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser<string>
    {
        public User()
        {
            this.Purchases = new HashSet<Purchase>();
        }
        
        public ICollection<Purchase> Purchases { get; set; }

        public ICollection<SubscriptionPurchase> SubscriptionPurchases { get; set; }

        public ICollection<Receipt> Receipts { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        
        [ForeignKey("Address")] public string AddressId { get; set; }
        public Address Address { get; set; }
    }
}