namespace TestMarket.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using System.Threading.Tasks;
    using TestMarket.Data;
    using TestMarket.Entities;
    using TestMarket.Repositories.Interfaces;
    public class ShoppingCartItemRepository : IShoppingCartItemRepository
    {
        private readonly DataContext _context;

        public ShoppingCartItemRepository(DataContext context)
        {
            _context = context;
        }

        public void Add(ShoppingCartItem item)
        {
            _context.ShoppingCartItems.Add(item);
        }

        public void AddRange(IEnumerable<ShoppingCartItem> items)
        {
            _context.ShoppingCartItems.AddRange(items);
        }

        public async Task<IEnumerable<ShoppingCartItem>> GetAllItemsWhere(Expression<Func<ShoppingCartItem, bool>> predicate)
        {
            return await _context.ShoppingCartItems.Where(predicate).ToListAsync();
        }

        //public async Task<IEnumerable<ShoppingCartItem>> GetAllItems()
        //{
        //    return await _context.ShoppingCartItems.ToListAsync();
        //}

        public async Task<IEnumerable<ShoppingCartItem>> GetAllItemsWhereFull(string ShoppingCartId)
        {
            var result = await _context.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId).Include(s => s.Product).ToListAsync();
            return result;
        }

        public async Task<ShoppingCartItem> GetItemWhere(Expression<Func<ShoppingCartItem, bool>> predicate)
        {
            return await _context.ShoppingCartItems.FirstOrDefaultAsync(predicate);
        }

        public void Remove(ShoppingCartItem item)
        {
            _context.ShoppingCartItems.Remove(item);
        }

        public void RemoveRange(IEnumerable<ShoppingCartItem> items)
        {
            _context.ShoppingCartItems.RemoveRange(items);
        }
    }
}
