using System.Linq.Expressions;

namespace DisasterResponseSystem.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(int? id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        int Sum(Expression<Func<TEntity, int>> selector);

        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}
