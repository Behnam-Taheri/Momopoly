using Tactical.Framework.Domain.DomainAbstractions;
using Tactical.Monopoly.Domain.Boards.Entities;
using Tactical.Monopoly.Domain.Boards.ValueObjects;

namespace Tactical.Monopoly.Domain.Boards
{
    public partial class Board : AggregateRoot<Guid>
    {
        private List<Cell> _cells = new();
        private List<BoardScore> _boardScores = new();


        public DateTime GameStartTime { get; set; }
        public IReadOnlyCollection<Cell> Cells => _cells;
        public IReadOnlyCollection<BoardScore> BoardScores => _boardScores;
    }
}
