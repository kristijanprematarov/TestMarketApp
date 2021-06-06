using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestMarket.Repositories;

namespace TestMarket.DTOs
{
    public class ShoppingCartDTO
    {
        public IShoppingCart ShoppingCart { get; set; }
        public decimal ShoppingCartTotal { get; set; }
    }
}
