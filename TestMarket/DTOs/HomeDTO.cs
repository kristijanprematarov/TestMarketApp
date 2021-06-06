namespace TestMarket.DTOs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TestMarket.Entities;

    public class HomeDTO
    {
        public IEnumerable<Product> Products { get; set; }
    }
}
