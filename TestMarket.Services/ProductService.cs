using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestMarket.Entities;
using TestMarket.Repositories.Interfaces;
using TestMarket.Services.Interfaces;

namespace TestMarket.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _productRepository.GetAll();
        }

        public async Task<Product> GetProduct(Guid id)
        {
            return await _productRepository.Get(id);
        }

        public async Task<Product> GetProductWhere(Expression<Func<Product, bool>> predicate)
        {
            var result = await _productRepository.GetProductWhere(predicate);
            return result;
        }
    }
}
