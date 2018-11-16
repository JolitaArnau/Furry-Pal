namespace FurryPal.Models
{
    using System;

    public class Receipt
    {
        public Receipt()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        
        public string Id { get; set; }

        public Purchase Purchase { get; set; }
    }
}