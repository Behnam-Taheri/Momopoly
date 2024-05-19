using Tactical.Framework.Application.CQRS.CommandHandling;


namespace Tactical.Monopoly.Application.Contract.Boards.Commands
{
    public record MovePlayerCommand(Guid BoardId,Guid PlayerId,int DiceNumber) : ICommand;


}
