using Tactical.Framework.Domain.DomainAbstractions;
using Tactical.Monopoly.Domain.Boards.Entities;
using Tactical.Monopoly.Domain.Boards.ValueObjects;

namespace Tactical.Monopoly.Domain.Boards
{
    public partial class Board : AggregateRoot<Guid>
    {
        private List<Cell> cells;
        private List<BoardScore> boardScore;

        public DateTime GameStartTime { get; set; }
        public IReadOnlyCollection<Cell> Cells => cells.AsReadOnly();
        public IReadOnlyCollection<BoardScore> BoardScores => boardScore.AsReadOnly();
    }
}
