using System;

namespace FurryPal.Models
{
    public class Address
    {
        public Guid Id { get; set; }

        public string ZipCode { get; set; }

        public string CountryName { get; set; }

        public string CityName { get; set; }
        
        public string ProvinceName { get; set; }

        public string StreetName { get; set; }

        public int HouseNumber { get; set; }
    }
}