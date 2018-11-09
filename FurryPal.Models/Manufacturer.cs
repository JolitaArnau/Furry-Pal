using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace FurryPal.Models
{
    public class Manufacturer
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }
        
        [ForeignKey("Address")]
        public Guid AddressId { get; set; }
        public Address Address { get; set; }
    }
}