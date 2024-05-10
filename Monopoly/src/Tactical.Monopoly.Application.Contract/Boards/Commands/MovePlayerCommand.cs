using Tactical.Framework.Application.CQRS.CommandHandling;


namespace Tactical.Monopoly.Application.Contract.Boards.Commands
{
    public record MovePlayerCommand(Guid BoardId,long PlayerId,int DiceNumber) : ICommand;


}
