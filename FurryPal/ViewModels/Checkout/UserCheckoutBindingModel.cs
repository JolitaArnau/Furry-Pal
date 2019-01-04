using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FurryPal.Models;

namespace FurryPal.Web.ViewModels.Checkout
{
    public class UserCheckoutBindingModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }

        [Display(Name = "Country")]
        public string CountryName { get; set; }
        
        [Display(Name = "City")]
        public string CityName { get; set; }

        [Display(Name = "Street Name")]
        public string StreetName { get; set; }

        [Display(Name = "House Number")]
        public int HouseNumber { get; set; }

        public List<Purchase> Purchases { get; set; }
    }
}