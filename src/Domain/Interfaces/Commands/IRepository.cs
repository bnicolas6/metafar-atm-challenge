using System.Linq.Expressions;

namespace Metafar.ATM.Challenge.Domain.Interfaces.Commands
{
    public interface IRepository<TEntity> 
        where TEntity : class
    {
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> FindByAsync(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> GetAllAsync();
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        Task SaveChangesAsync();
    }
}
