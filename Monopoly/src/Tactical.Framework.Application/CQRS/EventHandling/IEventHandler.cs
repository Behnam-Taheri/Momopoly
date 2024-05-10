using Tactical.Framework.Core.Abstractions;

namespace Tactical.Framework.Application.CQRS.EventHandling;

public interface IEventHandler
{
}
public interface IEventHandler<in TEvent> : IEventHandler where TEvent : IEvent
{
    public Task HandleAsync(TEvent e);
}
