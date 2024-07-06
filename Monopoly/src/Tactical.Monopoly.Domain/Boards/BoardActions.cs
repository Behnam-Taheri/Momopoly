using Tactical.Monopoly.Domain.Boards.Entities;
using Tactical.Monopoly.Domain.Boards.Events;
using Tactical.Monopoly.Domain.Boards.Factories;
using Tactical.Monopoly.Domain.Boards.ValueObjects;

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
            QueueEvent(new BoardCreatedEvent());
        }

        public void MovePlayer(Guid playerId, int diceNumber)
        {
            ValidateDiceNumber(diceNumber);
            var currentCell = ChangeCell(playerId, diceNumber);
            CheckOwners(currentCell, playerId);
        }

        private void CheckOwners(Cell cell, Guid playerId)
        {
            if (cell.OwnerId != default && cell.OwnerId != playerId)
            {
                var playerScore = _boardScores.First(x => x.PlayerId == playerId);
                playerScore = playerScore.MinusScore(cell.GetCost());
            }

        }

        public void BuyCell(short position, Guid playerId)
        {
            var cell = FindCellByPosition(position);
            cell.Buy(playerId);
        }

        private Cell ChangeCell(Guid playerId, int diceNumber)
        {
            var currentPosition = GetAndRemoveCurrentPosition(playerId);

            var nextPosition = currentPosition + diceNumber;

            if (currentPosition > 20 && nextPosition > CountOfCell)
                nextPosition = CountOfCell - currentPosition;

            var nextPositionCell = FindCellByPosition((short)nextPosition);

            nextPositionCell.AddPlayer(playerId);

            return nextPositionCell;
        }

        private short GetAndRemoveCurrentPosition(Guid playerId)
        {
            var currentPositionCell = FindCellByPlayerId(playerId);
            currentPositionCell.RemovePlayer(playerId);
            return currentPositionCell.Position;
        }

        private Cell FindCellByPlayerId(Guid playerId) => _cells.First(x => x.PlayerIds.Any(i => i.Value == playerId));
        private Cell FindCellByPosition(short position) => _cells.First(x => x.Position == position);

        private static void ValidateDiceNumber(int diceNumber)
        {
            if (diceNumber is > 6 or < 1)
                throw new Exception();
        }

        private void ReplaceScore(BoardScore score)
        {

        }
    }
}
