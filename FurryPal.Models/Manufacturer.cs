using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace FurryPal.Models
{
    public class Manufacturer
    {
        public Manufacturer()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        
        public string Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }
        
        [ForeignKey("Address")]
        public string AddressId { get; set; }
        public Address Address { get; set; }
    }
}