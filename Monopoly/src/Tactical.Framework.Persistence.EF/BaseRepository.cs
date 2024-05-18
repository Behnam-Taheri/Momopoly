using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Tactical.Framework.Persistence.EF
{

    public abstract class BaseRepository<TAggregate> : IRepository<TAggregate> where TAggregate : class
    {
        private readonly DbContext _context;

        protected BaseRepository(DbContext context)
        {
            _context = context;
        }

        public void Delete(TAggregate aggregate)
        {
            _context.Set<TAggregate>().Remove(aggregate);
        }

        public TAggregate? Get(Expression<Func<TAggregate, bool>> predicate)
        {
            return _context.Set<TAggregate>().FirstOrDefault(predicate);
        }

        public async Task<TAggregate?> GetAsync(Expression<Func<TAggregate, bool>> predicate, CancellationToken cancellationToken)
        {
            return await _context.Set<TAggregate>().FirstOrDefaultAsync(predicate, cancellationToken);
        }

        public async Task CreateAsync(TAggregate aggregate)
        {
            await _context.Set<TAggregate>().AddAsync(aggregate);
        }

        public void SaveChanges(TAggregate aggregate)
        {
            throw new NotImplementedException();
        }
    }
}
