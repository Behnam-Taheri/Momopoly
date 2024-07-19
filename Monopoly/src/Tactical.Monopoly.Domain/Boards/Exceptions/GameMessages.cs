namespace Tactical.Monopoly.Domain.Boards.Exceptions
{
    public struct GameMessages
    {
        public const string BoughtCell = "player {title} bought {cell}";
        public const string HouseCreated = "player {title} Created House On {cell}";
    }

    public struct GameException
    {
        public const string NotBuyableCell = "you can't buy NotBuyableCell";
        public const string CellHasOwner = "you can't buy cell with owner";
        public const string MaximumNumberOfHouse = "you can't create more than maximum number of house";
        public const string NotManufacturableCell = "you can't create house in NotManufacturableCell";
        public const string NotBuyAllRelated = "you can't create house when you didn't buy all related cells";
        public const string InvalidDiceNumber = "Invalid Dice Number";
        
    }
}
