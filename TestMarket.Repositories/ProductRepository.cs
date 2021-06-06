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

    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly DataContext _context;

        public ProductRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Product> GetProductWhere(Expression<Func<Product, bool>> predicate)
        {
            return await _context.Products.FirstOrDefaultAsync(predicate);
        }
    }
}
