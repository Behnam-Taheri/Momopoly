using Tactical.Monopoly.Domain.Boards.Entities;
using Tactical.Monopoly.Domain.Boards.Enums;
using Tactical.Monopoly.Domain.Boards.Events;
using Tactical.Monopoly.Domain.Boards.Exceptions;
using Tactical.Monopoly.Domain.Boards.Factories;
using Tactical.Monopoly.Domain.Boards.ValueObjects;

namespace Tactical.Monopoly.Domain.Boards
{
    public partial class Board
    {
        private const int CountOfCell = 24;
        private const int StartReward = 200;
        private const int JailPosition = 12;
        private const int JailPrice = 80;
        private Board() { }

        public Board(List<Guid> playerIds)
        {
            Id = Guid.NewGuid();
            GameStartTime = DateTime.UtcNow;
            _boardScores = BoardScoreFactory.Create(Id, playerIds);
            _cells = CellFactory.Create(Id, playerIds);
            QueueEvent(new BoardCreatedEvent { Id = Id });
        }

        public void MovePlayer(Guid playerId, int diceNumber)
        {
            ValidateDiceNumber(diceNumber);
            var currentCell = ChangeCell(playerId, diceNumber);
            CheckOwners(currentCell, playerId);
            CheckIfCellHasSpecialLogic(currentCell);
        }

        public void SendPlayerToJail(Guid playerId,bool stay)
        {
            if (!stay)
            {
                var playerScore = FindBoardScoresByPlayerId(playerId);
                playerScore.MinusScore(JailPrice);
            }
            else
            {

            }
        }

        private void CheckIfPlayerPassedStart(int previousPosition, int currentPosition, Guid playerId)
        {
            if (currentPosition < previousPosition)
            {
                var playerScore = FindBoardScoresByPlayerId(playerId);
                playerScore.AddScore(StartReward);
            }
        }

        public void BuyCell(short position, Guid playerId)
        {
            var cell = FindCellByPosition(position);
            cell.Buy(playerId);
            var playerScore = FindBoardScoresByPlayerId(playerId);
            playerScore.MinusScore(cell.Price);

            QueueEvent(new CellBoughtEvent() { Message = PrepareMessage(cell, GameMessages.BoughtCell) });
        }

        public void CreateHouse(short position, Guid playerId)
        {
            var cell = FindCellByPosition(position);
            var relatedCells = FindCellsByGroup(cell.Group);
            cell.CreateHouse(relatedCells, playerId);
            var playerScore = FindBoardScoresByPlayerId(playerId);
            playerScore.MinusScore(cell.PriceOfHouse);
            QueueEvent(new HouseCreatedEvent() { Message = PrepareMessage(cell, GameMessages.HouseCreated) });
        }

        private Cell ChangeCell(Guid playerId, int diceNumber)
        {
            var currentPosition = GetAndRemoveCurrentPosition(playerId);

            var nextPosition = currentPosition + diceNumber;

            if (nextPosition >= CountOfCell)
                nextPosition -= CountOfCell;

            var nextPositionCell = FindCellByPosition((short)nextPosition);

            nextPositionCell.AddPlayer(playerId);

            CheckIfPlayerPassedStart(currentPosition, nextPosition, playerId);
            
            return nextPositionCell;
        }

        private void CheckIfCellHasSpecialLogic(Cell nextPositionCell)
        {
            if (nextPositionCell.Position == JailPosition)
            {
                QueueEvent(new PlayerMovedToJailEvent() { Position = JailPosition });
            }
        }

        private void CheckOwners(Cell cell, Guid playerId)
        {
            if (cell.OwnerId != default && cell.OwnerId != playerId)
            {
                var playerScore = FindBoardScoresByPlayerId(playerId);
                playerScore.MinusScore(cell.GetCost());
            }
        }

        private short GetAndRemoveCurrentPosition(Guid playerId)
        {
            var currentPositionCell = FindCellByPlayerId(playerId);
            currentPositionCell.RemovePlayer(playerId);
            return currentPositionCell.Position;
        }

        private Cell FindCellByPlayerId(Guid playerId) => _cells.First(x => x.PlayerIds.Any(i => i.Value == playerId));
        private Cell FindCellByPosition(short position) => _cells.First(x => x.Position == position);
        private List<Cell> FindCellsByGroup(Group group) => _cells.Where(x => x.Group == group).ToList();
        private BoardScore FindBoardScoresByPlayerId(Guid playerId) => _boardScores.First(x => x.PlayerId == playerId);

        private static void ValidateDiceNumber(int diceNumber)
        {
            if (diceNumber is > 6 or < 1)
                throw new InvalidDiceNumberException(GameException.InvalidDiceNumber);
        }

        private void ReplaceScore(BoardScore score)
        {

        }

        private static string PrepareMessage(Cell cell, string message)
        {
            return message.Replace("{title}", cell.OwnerId.ToString()).Replace("{cell}", cell.Name);
        }
    }
}
