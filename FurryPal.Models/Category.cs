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
            this.SubCategories = new HashSet<SubCategory>();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<SubCategory> SubCategories { get; set; }
    }
}