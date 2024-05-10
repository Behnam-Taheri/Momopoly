using Tactical.Framework.Application.CQRS.CommandHandling;
namespace Tactical.Monopoly.Application.Contract.Boards.Commands
{
    public record CreateBoardCommand : ICommand
    {
        public List<Guid> PlayerIds { get; set; }
    }
}
