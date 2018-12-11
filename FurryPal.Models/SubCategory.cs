namespace FurryPal.Models
{
    using System;
    
    public class SubCategory
    {
        public SubCategory()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}