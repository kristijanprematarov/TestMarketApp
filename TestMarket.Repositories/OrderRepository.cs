using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMarket.Data;
using TestMarket.Entities;
using TestMarket.Repositories.Interfaces;

namespace TestMarket.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private readonly DataContext _context;

        public OrderRepository(
            DataContext context) : base(context)
        {
            _context = context;
        }

        public void CreateOrder(Order order, decimal shoppingCartTotal)
        {
            order.OrderPlaced = DateTime.Now;

            var shoppingCartItems = _context.ShoppingCartItems.AsEnumerable();
            order.OrderTotal = shoppingCartTotal;

            order.OrderDetails = new List<OrderDetail>();
            //adding the order with its details

            foreach (var shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail
                {
                    Amount = shoppingCartItem.Amount,
                    ProductId = shoppingCartItem.Product.ProductId,
                    Price = shoppingCartItem.Product.Price
                };

                order.OrderDetails.Add(orderDetail);
            }

            _context.Orders.Add(order);
            _context.SaveChanges();
        }
    }
}
