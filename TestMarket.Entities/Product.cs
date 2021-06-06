namespace TestMarket.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Product
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int TimesBought { get; set; }
        public string ImageUrl { get; set; }
        public string ImageThumbnailUrl { get; set; }
    }
}
