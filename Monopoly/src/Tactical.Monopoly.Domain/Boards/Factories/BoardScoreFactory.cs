using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tactical.Monopoly.Domain.Boards.ValueObjects;

namespace Tactical.Monopoly.Domain.Boards.Factories
{
    internal class BoardScoreFactory
    {
        internal static List<BoardScore> Create(Guid boardId, List<Guid> playerIds)=> playerIds.Select(x => new BoardScore(500, x, boardId)).ToList();
    }
}
