namespace Tactical.Framework.Application.CQRS.CommandHandling;

public interface ICommandBus
{
    Task DispatchAsync<TCommand>(TCommand command, CancellationToken cancellationToken) where TCommand : ICommand;
    ICommandFluent Execute<TCommand>(TCommand command) where TCommand : ICommand;
}
