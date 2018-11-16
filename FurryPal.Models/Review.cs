namespace FurryPal.Models
{
    using System;
    
    public class Review
    {
        public Review()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        
        public string Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
    }
}