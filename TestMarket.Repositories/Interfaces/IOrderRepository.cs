namespace TestMarket.Repositories.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TestMarket.Entities;

    public interface IOrderRepository : IRepository<Order>
    {
        void CreateOrder(Order order, decimal shoppingCartTotal);
    }
}
