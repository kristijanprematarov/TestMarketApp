namespace TestMarket.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TestMarket.Entities;
    using TestMarket.Repositories;
    using TestMarket.Repositories.Interfaces;
    using TestMarket.Services.Interfaces;
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IShoppingCart _shoppingCart;

        public OrderService(IOrderRepository orderRepository, IShoppingCart shoppingCart)
        {
            _orderRepository = orderRepository;
            _shoppingCart = shoppingCart;
        }

        public void CreateOrder(Order order)
        {
            var shoppingCartTotal = _shoppingCart.GetShoppingCartTotal();
            _orderRepository.CreateOrder(order, shoppingCartTotal);
        }
    }
}
