using System.Collections.Generic;
using Tactical.Framework.Core.Abstractions;
using Tactical.Monopoly.Domain.Boards.Enums;
using Tactical.Monopoly.Domain.Boards.ValueObjects;

namespace Tactical.Monopoly.Domain.Boards.Entities
{
    public class Cell : Entity<short>
    {
        private const int MaxNumberOfHouse = 3;
        private List<PlayerId> playerIds = new();
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

        //public Cell(short id)
        //{
        //    Id = id;
        //}
        public Guid BoardId { get; private set; }
        public string Name { get; private set; }
        public short Position { get; private set; }
        public Group Group { get; private set; }
        public short Price { get; private set; }
        public bool Buyable { get; private set; }
        public Guid OwnerId { get; private set; }

        public IReadOnlyCollection<PlayerId> PlayerIds => playerIds.AsReadOnly();

        //TODO
        //ICon

        //TODO move To class
        public int NumberOfHouse { get; private set; }
        public bool Manufacturable { get; private set; }
        public int PriceOfHouse { get; private set; }



        public void BuyValidate()
        {
            //Not Assigned
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
    }
}
