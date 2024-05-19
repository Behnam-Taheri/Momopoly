using Tactical.Monopoly.Domain.Boards.Entities;
using Tactical.Monopoly.Domain.Boards.Factories;

namespace Tactical.Monopoly.Domain.Boards
{
    public partial class Board
    {
        private const int CountOfCell = 26;
        private Board() { }

        public Board(List<Guid> playerIds)
        {
            Id = Guid.NewGuid();
            GameStartTime = DateTime.UtcNow;
            _boardScores = BoardScoreFactory.Create(Id, playerIds);
            _cells = CellFactory.Create(Id, playerIds);
        }

        public void MovePlayer(Guid playerId, int diceNumber)
        {
            ValidateDiceNumber(diceNumber);
            ChangeCell(playerId, diceNumber);
            CheckOwners();
        }

        private void CheckOwners()
        {
            throw new NotImplementedException();
        }

        public void BuyCell(short cellId, long playerId)
        {
            var cell = Cells.First(x => x.Id == cellId);
            cell.BuyValidate();
        }

        private void ChangeCell(Guid playerId, int diceNumber)
        {
            var currentPosition = GetAndRemoveCurrentPosition(playerId);

            var nextPosition = currentPosition + diceNumber;

            if (currentPosition > 20 && nextPosition > CountOfCell)
                nextPosition = CountOfCell - currentPosition;


            var nextPositionCell = FindCellByPosition((short)nextPosition);

            nextPositionCell.AddPlayer(playerId);
        }

        private short GetAndRemoveCurrentPosition(Guid playerId)
        {
            var currentPositionCell = FindCellByPlayerId(playerId);
            currentPositionCell.RemovePlayer(playerId);
            return currentPositionCell.Position;
        }

        private Cell FindCellByPlayerId(Guid playerId) => _cells.Where(x => x.PlayerIds.Any(x => x.Value == playerId)).First();
        private Cell FindCellByPosition(short position) => _cells.First(x => x.Position == position);

        private static void ValidateDiceNumber(int diceNumber)
        {
            if (diceNumber is > 6 or < 1)
                throw new Exception();
        }
    }
}
