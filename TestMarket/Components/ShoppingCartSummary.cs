namespace TestMarket.Components
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TestMarket.DTOs;
    using TestMarket.Repositories;
    using TestMarket.Services.Interfaces;

    public class ShoppingCartSummary : ViewComponent
    {
        private readonly IShoppingCart _shoppingCart;

        public ShoppingCartSummary(IShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        public IViewComponentResult Invoke()
        {
            var items = _shoppingCart.GetShoppingCartItemsWithProducts();
            _shoppingCart.SetShoppingCartItems(items);

            var shoppingCartDTO = new ShoppingCartDTO
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            return View(shoppingCartDTO);
        }
    }
}
