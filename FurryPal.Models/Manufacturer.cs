namespace FurryPal.Models
{
    using System;
    
    public class Manufacturer
    {
        public Manufacturer(string id, string name, string email, string phoneNumber)
        {
            this.Id = id;
            this.Name = name;
            this.Email = email;
            this.PhoneNumber = phoneNumber;
        }
        
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