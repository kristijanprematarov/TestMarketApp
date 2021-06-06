namespace TestMarket.Services.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TestMarket.Entities;

    public interface IOrderService
    {
        void CreateOrder(Order order);
    }
}
