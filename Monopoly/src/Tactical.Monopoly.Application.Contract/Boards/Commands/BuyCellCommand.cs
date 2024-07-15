using Tactical.Framework.Application.CQRS.CommandHandling;

namespace Tactical.Monopoly.Application.Contract.Boards.Commands
{
    public record BuyCellCommand(Guid BoardId, short Position, Guid PlayerId) : ICommand;
    public record CreateHouseCommand(Guid BoardId, short Position, Guid PlayerId) : ICommand;
    public record SellHouseCommand(Guid BoardId, short Position, Guid PlayerId) : ICommand;
    public record MortgageCellCommand(Guid BoardId, short Position, Guid PlayerId) : ICommand;
    public record RemoveMortgageCell(Guid BoardId, short Position, Guid PlayerId) : ICommand;

}
