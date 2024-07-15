using Tactical.Monopoly.Application.Contract.Boards.Commands;

namespace Tactical.Monopoly.EndPoint.Api.Requests
{
    public record ChangeCellRequest()
    {
        public short Position { get; set; }
        public Guid PlayerId { get; set; }

        public BuyCellCommand ToBuyCellCommand(Guid boardId) => new(boardId, Position, PlayerId);
        public CreateHouseCommand ToCreateHouseCommand(Guid boardId) => new(boardId, Position, PlayerId);
    }
   
}
