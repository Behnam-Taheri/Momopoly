using Tactical.Monopoly.Domain.Boards.Factories;

namespace Tactical.Monopoly.Domain.Boards
{
    public partial class Board
    {
        private Board() { }

        public Board(List<Guid> playerIds)
        {
            Id = Guid.NewGuid();
            GameStartTime = DateTime.UtcNow;
            boardScore = BoardScoreFactory.Create(Id, playerIds);
            cells = CellFactory.Create(Id, playerIds);
        }

        public void MovePlayer(Guid playerId, int diceNumber)
        {
            var currentPositionCell = cells.Where(x => x.PlayerIds.Any(x => x.Value == playerId)).First();
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
