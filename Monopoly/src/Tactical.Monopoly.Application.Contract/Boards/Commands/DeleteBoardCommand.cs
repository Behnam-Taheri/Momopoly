using Tactical.Framework.Application.CQRS.CommandHandling;


namespace Tactical.Monopoly.Application.Contract.Boards.Commands
{
    public record DeleteBoardCommand(Guid BoardId) : ICommand;
}
