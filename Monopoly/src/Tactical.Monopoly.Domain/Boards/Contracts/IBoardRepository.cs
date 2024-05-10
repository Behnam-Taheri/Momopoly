using System.Linq.Expressions;

namespace Tactical.Monopoly.Domain.Boards.Contracts
{
    public interface IBoardRepository
    {
        Task CreateAsync(Board board);
        Task<Board?> GetAsync(Expression<Func<Board, bool>> predicate, CancellationToken cancellationToken);

        void Delete(Board board);
    }
}
