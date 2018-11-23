namespace FurryPal.Models
{
    using System;
    
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
    }
}