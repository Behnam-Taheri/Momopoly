using Tactical.Monopoly.Domain.Boards.Enums;
using Tactical.Monopoly.Domain.Boards.ValueObjects;

namespace Tactical.Monopoly.Domain.Boards.Entities
{
    public partial class Cell
    {
        private Cell() { }
        public Cell(Guid boardId, string name, short position, Group group, short price, bool buyable, bool manufacturable, int priceOfHouse)
        {
            BoardId = boardId;
            Name = name;
            Position = position;
            Group = group;
            Price = price;
            Buyable = buyable;
            Manufacturable = manufacturable;
            PriceOfHouse = priceOfHouse;
        }

        public void Buy(Guid playerId)
        {
            if (!Buyable) throw new Exception();

            if (OwnerId != default) throw new Exception();

            OwnerId = playerId;
        }

        public void MakeHouse()
        {
            if (NumberOfHouse < MaxNumberOfHouse)
                NumberOfHouse++;
            else
                throw new Exception();
        }

        public void SetStartCell(List<Guid> playerIds)
        {
            foreach (var playerId in playerIds)
            {
                this.playerIds.Add(new PlayerId(playerId));
            }
        }

        public void AddPlayer(Guid playerId)
        {
            playerIds.Add(new PlayerId(playerId));
        }

        public void RemovePlayer(Guid playerId)
        {
            playerIds.Remove(new PlayerId(playerId));
        }

        public int GetCost() => Manufacturable ? (NumberOfHouse * PriceOfHouse) + Price : Price;
    }
}
