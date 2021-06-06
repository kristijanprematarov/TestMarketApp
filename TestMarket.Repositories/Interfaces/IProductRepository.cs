namespace TestMarket.Repositories.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Text;
    using System.Threading.Tasks;
    using TestMarket.Entities;

    public interface IProductRepository : IRepository<Product>
    {
        Task<Product> GetProductWhere(Expression<Func<Product, bool>> predicate);
    }
}
