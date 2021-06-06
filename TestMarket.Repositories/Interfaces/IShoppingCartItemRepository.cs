namespace TestMarket.Repositories.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using System.Threading.Tasks;
    using TestMarket.Entities;
    public interface IShoppingCartItemRepository
    {
        //FIND
        Task<ShoppingCartItem> GetItemWhere(Expression<Func<ShoppingCartItem, bool>> predicate);
        Task<IEnumerable<ShoppingCartItem>> GetAllItemsWhere(Expression<Func<ShoppingCartItem, bool>> predicate);
        Task<IEnumerable<ShoppingCartItem>> GetAllItemsWhereFull(string ShoppingCartId);

        //ADD
        void Add(ShoppingCartItem item);
        void AddRange(IEnumerable<ShoppingCartItem> items);

        //Remove
        void Remove(ShoppingCartItem entity);
        void RemoveRange(IEnumerable<ShoppingCartItem> entities);
    }
}
