using System.Collections.Generic;
using Tactical.Framework.Core.Abstractions;
using Tactical.Monopoly.Domain.Boards.Enums;
using Tactical.Monopoly.Domain.Boards.ValueObjects;

namespace Tactical.Monopoly.Domain.Boards.Entities
{
    public partial class Cell : Entity<short>
    {
        private const int MaxNumberOfHouse = 3;
        private List<PlayerId> playerIds = new();
       
        
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

     
    }
}
