using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Linq.Expressions;
using Tactical.Framework.Core.Abstractions;

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
            var aggregate = ConvertToAggregate(_context.Set<TAggregate>());
            return aggregate.FirstOrDefault(predicate);
        }

        public async Task<TAggregate?> GetAsync(Expression<Func<TAggregate, bool>> predicate, CancellationToken cancellationToken)
        {
            var aggregate = ConvertToAggregate(_context.Set<TAggregate>());
            return await aggregate.FirstOrDefaultAsync(predicate, cancellationToken);
        }

        public async Task CreateAsync(TAggregate aggregate)
        {
            await _context.Set<TAggregate>().AddAsync(aggregate);
        }

        public void SaveChanges(TAggregate aggregate)
        {
            throw new NotImplementedException();
        }

        protected abstract Expression<Func<TAggregate, object>>[] GetIncludeExpressions();

        private IQueryable<TAggregate> ConvertToAggregate(IQueryable<TAggregate> set)
        {
            var result = set;
            var includeExpressions = GetIncludeExpressions();

            if (includeExpressions != null)
            {
                foreach (var expression in includeExpressions)
                {
                    result = result.Include(expression);
                }
            }

            return result;
        }
    }

    public interface IRepository<TAggregate> where TAggregate : class
    {
        Task CreateAsync(TAggregate aggregate);
        void SaveChanges(TAggregate aggregate);
        void Delete(TAggregate aggregate);
        TAggregate? Get(Expression<Func<TAggregate, bool>> predicate);
        Task<TAggregate?> GetAsync(Expression<Func<TAggregate, bool>> predicate, CancellationToken cancellationToken);

    }
}
