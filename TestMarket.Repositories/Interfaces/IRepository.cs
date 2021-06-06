namespace TestMarket.Repositories.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using System.Threading.Tasks;

    public interface IRepository<TEntity> where TEntity : class
    {
        //FIND
        Task<TEntity> Get(Guid id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<IEnumerable<TEntity>> GetAllWhere(Expression<Func<TEntity, bool>> predicate);

        //ADD
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        //Remove
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);

    }
}
