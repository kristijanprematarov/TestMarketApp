namespace TestMarket.Services.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using System.Threading.Tasks;
    using TestMarket.Entities;

    public interface IProductService
    {
        Task<Product> GetProduct(Guid id);
        Task<Product> GetProductWhere(Expression<Func<Product, bool>> predicate);
        Task<IEnumerable<Product>> GetAllProducts();
    }
}
