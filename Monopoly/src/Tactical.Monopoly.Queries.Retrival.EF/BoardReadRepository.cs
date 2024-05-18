using Microsoft.EntityFrameworkCore;
using Tactical.Monopoly.Queries.Contracts;
using Tactical.Monopoly.Queries.EF;
using Tactical.Monopoly.Queries.EF.Models;

namespace Tactical.Monopoly.Queries.Retrieval.EF
{
    public class BoardReadRepository : IBoardReadRepository
    {
        private readonly RetrievalDbContext _context;

        public BoardReadRepository(RetrievalDbContext context)
        {
            _context = context;
        }

        public Task<Board?> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            return _context.Boards.Where(x => x.Id == id)
                .Include(x => x.Cells)
                .ThenInclude(x => x.PlayerIds)
                .Include(x=>x.BoardScores)
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}
