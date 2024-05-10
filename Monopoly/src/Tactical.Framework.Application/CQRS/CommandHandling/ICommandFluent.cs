using Tactical.Framework.Core.Abstractions;

namespace Tactical.Framework.Application.CQRS.CommandHandling;

public interface ICommandFluent
{
    ICommandFluent On<TEvent>(Action<TEvent> action) where TEvent : IEvent;

    Task DispatchAsync(CancellationToken cancellationToken);
}
