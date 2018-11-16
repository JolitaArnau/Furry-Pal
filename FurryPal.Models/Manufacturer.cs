namespace FurryPal.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    
    public class Manufacturer
    {
        public Manufacturer()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        
        public string Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }
        
        [ForeignKey("Address")]
        public string AddressId { get; set; }
        public Address Address { get; set; }
    }
}