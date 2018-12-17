namespace FurryPal.Models
{
    using System.Collections.Generic;
    using System;

    public class Category
    {
        public Category(string id, string name, string description)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
        }

        public Category()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}