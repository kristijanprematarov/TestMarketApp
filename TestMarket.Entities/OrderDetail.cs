namespace TestMarket.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class OrderDetail
    {
        public Guid OrderDetailId { get; set; }
        public Product Product { get; set; }
        public Guid ProductId { get; set; }
        public Order Order { get; set; }
        public int OrderId { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
    }
}
