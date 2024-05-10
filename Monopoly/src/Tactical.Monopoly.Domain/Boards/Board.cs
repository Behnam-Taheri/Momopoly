using Tactical.Framework.Domain.DomainAbstractions;
using Tactical.Monopoly.Domain.Boards.Entities;
using Tactical.Monopoly.Domain.Boards.Factories;
using Tactical.Monopoly.Domain.Boards.ValueObjects;

namespace Tactical.Monopoly.Domain.Boards
{
    public class Board : AggregateRoot<Guid>
    {
        private List<Cell> cells;
        private List<BoardScore> boardScore;
        private Board() { }

        public Board(List<Guid> playerIds)
        {
            Id = Guid.NewGuid();
            GameStartTime = DateTime.UtcNow;
            boardScore = BoardScoreFactory.Create(Id, playerIds);
            cells = CellFactory.Create(Id, playerIds);
        }

        public DateTime GameStartTime { get; set; }
        public IReadOnlyCollection<Cell> Cells => cells.AsReadOnly();
        public IReadOnlyCollection<BoardScore> BoardScores => boardScore.AsReadOnly();

        public void MovePlayer(Guid playerId, int diceNumber)
        {
            var currentPositionCell = cells.Where(x => x.CellPlayerIds.Any(x => x.Value == playerId)).First();
            currentPositionCell.RemovePlayer(playerId);
            var currentPosition = currentPositionCell.Position;

            var temp = currentPosition + diceNumber;

            if (temp > 0) { }
        }

        public void BuyCell(short cellId, long playerId)
        {
            var cell = Cells.First(x => x.Id == cellId);
            cell.BuyValidate();
        }
    }
}
