namespace TestMarket.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using TestMarket.DTOs;
    using TestMarket.Repositories;
    using TestMarket.Services.Interfaces;

    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCart _shoppingCart;
        private readonly IProductService _productService;

        public ShoppingCartController(
            IShoppingCart shoppingCartService,
            IProductService productService)
        {
            _shoppingCart = shoppingCartService;
            _productService = productService;
        }
        public IActionResult Index()
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

        public RedirectToActionResult AddToShoppingCart(Guid productId)
        {
            var selectedProduct = _productService.GetProduct(productId).Result;

            if (selectedProduct != null)
            {
                _shoppingCart.AddToCart(selectedProduct);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(Guid productId)
        {
            var selectedProduct = _productService.GetProduct(productId).Result;

            if (selectedProduct != null)
            {
                _shoppingCart.RemoveFromCart(selectedProduct);
            }
            return RedirectToAction("Index");
        }
    }
}
