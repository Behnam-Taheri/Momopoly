using System.Linq.Expressions;

namespace Tactical.Framework.Persistence.EF
{
    public interface IRepository<TAggregate> where TAggregate : class
    {
        Task CreateAsync(TAggregate aggregate);
        void SaveChanges(TAggregate aggregate);
        void Delete(TAggregate aggregate);
        TAggregate? Get(Expression<Func<TAggregate, bool>> predicate);
        Task<TAggregate?> GetAsync(Expression<Func<TAggregate, bool>> predicate, CancellationToken cancellationToken);
    }
}
