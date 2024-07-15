using Tactical.Framework.Core.Abstractions;

namespace Tactical.Framework.Application.CQRS.CommandHandling;

public interface ICommandHandler<in TCommand> : ICommandHandler
    where TCommand : ICommand
{
    abstract Task HandleAsync(TCommand command, CancellationToken cancellationToken);
}
