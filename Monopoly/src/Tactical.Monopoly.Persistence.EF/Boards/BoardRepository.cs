using System.Linq.Expressions;
using Tactical.Framework.Persistence.EF;
using Tactical.Monopoly.Domain.Boards;
using Tactical.Monopoly.Domain.Boards.Contracts;
using Tactical.Monopoly.Persistence.EF.Contexts;

namespace Tactical.Monopoly.Persistence.EF.Boards
{
    public class BoardRepository : BaseRepository<Board>, IBoardRepository
    {
        public BoardRepository(MonopolyContext context) : base(context)
        {

        }

        protected override Expression<Func<Board, object>>[] GetIncludeExpressions()
        {
            return new Expression<Func<Board, object>>[]
            {
                x=>x.Cells
            };
        }
    }
}
