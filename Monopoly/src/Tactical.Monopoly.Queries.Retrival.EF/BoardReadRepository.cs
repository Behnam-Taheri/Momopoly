using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Linq.Expressions;
using Tactical.Monopoly.Queries.Contracts;
using Tactical.Monopoly.Queries.Contracts.Options;
using Tactical.Monopoly.Queries.EF;
using Tactical.Monopoly.Queries.EF.Models;

namespace Tactical.Monopoly.Queries.Retrieval.EF
{
    public class BoardReadRepository : IBoardReadRepository
    {
        private readonly RetrievalDbContext dbContext;

        public BoardReadRepository(IOptionsMonitor<ConnectionStrings> options)
        {
            dbContext = new RetrievalDbContext(options.CurrentValue.MonopolyConnectionString!);
        }

        public Task<Board?> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            return dbContext.Boards.Where(x => x.Id == id).Include(x => x.Cells).ThenInclude(x => x.PlayerIds).FirstOrDefaultAsync(cancellationToken);
        }
    }
}
