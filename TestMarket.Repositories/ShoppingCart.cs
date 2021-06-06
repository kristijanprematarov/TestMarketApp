using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestMarket.Data;
using TestMarket.Entities;

namespace TestMarket.Repositories
{
    public class ShoppingCart : IShoppingCart
    {
        private readonly DataContext _context;

        public string ShoppingCartId { get; set; }

        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public void SetShoppingCartItems(List<ShoppingCartItem> items)
        {
            this.ShoppingCartItems = items;
        }

        public ShoppingCart(DataContext context)
        {
            _context = context;
        }

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;

            var context = services.GetService<DataContext>();

            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        public void AddToCart(Product product)
        {
            var shoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(item =>
                 item.Product.ProductId == product.ProductId && item.ShoppingCartId == ShoppingCartId);

            var setProductTB = _context.Products.FirstOrDefault(p => p.ProductId == product.ProductId);

            if (shoppingCartItem == null) //means this product is not in the cart yet
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Product = product,
                    Amount = 1,
                };
                setProductTB.TimesBought += 1;
                _context.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
                setProductTB.TimesBought++;
            }
            _context.SaveChanges();
        }

        public int RemoveFromCart(Product product)
        {
            var shoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(item =>
                 item.Product.ProductId == product.ProductId && item.ShoppingCartId == ShoppingCartId);

            var localAmount = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    _context.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }

            _context.SaveChanges();

            return localAmount;
        }

        public List<ShoppingCartItem> GetShoppingCartItemsWithProducts()
        {
            return ShoppingCartItems ??
                (ShoppingCartItems = _context.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                .Include(s => s.Product)
                .ToList());
        }

        public async Task ClearCart()
        {
            var cartItems = await _context.ShoppingCartItems.Where(cart => cart.ShoppingCartId == ShoppingCartId).ToListAsync();

            _context.ShoppingCartItems.RemoveRange(cartItems);

            await _context.SaveChangesAsync();
        }

        public decimal GetShoppingCartTotal()
        {
            var cartItems = _context.ShoppingCartItems.Where(cart => cart.ShoppingCartId == ShoppingCartId);
            var total = cartItems.Select(c => c.Product.Price * c.Amount).Sum();
            return total;
        }
    }
}
