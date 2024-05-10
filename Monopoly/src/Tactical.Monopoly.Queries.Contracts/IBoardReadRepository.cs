using System.Linq.Expressions;
using Tactical.Monopoly.Queries.EF.Models;

namespace Tactical.Monopoly.Queries.Contracts
{
    public interface IBoardReadRepository
    {
        Task<Board?> GetAsync(Guid id, CancellationToken cancellationToken);
    }
}
