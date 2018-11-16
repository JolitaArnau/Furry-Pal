namespace FurryPal.Models
{
    using System;

    public class Category
    {
        public Category()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}