using Tactical.Framework.Domain.DomainAbstractions;
using Tactical.Monopoly.Domain.Boards.Entities;
using Tactical.Monopoly.Domain.Boards.ValueObjects;

namespace Tactical.Monopoly.Domain.Boards
{
    public partial class Board : AggregateRoot<Guid>
    {
        private readonly List<Cell> _cells = [];
        private readonly List<BoardScore> _boardScores = [];


        public DateTime GameStartTime { get; set; }
        public IReadOnlyCollection<Cell> Cells => _cells;
        public IReadOnlyCollection<BoardScore> BoardScores => _boardScores;
    }
}
