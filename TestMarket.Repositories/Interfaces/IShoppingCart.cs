using System.Collections.Generic;
using System.Threading.Tasks;
using TestMarket.Entities;

namespace TestMarket.Repositories
{
    public interface IShoppingCart
    {
        void SetShoppingCartItems(List<ShoppingCartItem> items);
        void AddToCart(Product product);
        Task ClearCart();
        List<ShoppingCartItem> GetShoppingCartItemsWithProducts();
        decimal GetShoppingCartTotal();
        int RemoveFromCart(Product product);
    }
}