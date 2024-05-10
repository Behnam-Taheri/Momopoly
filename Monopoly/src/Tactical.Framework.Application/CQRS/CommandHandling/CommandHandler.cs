using Tactical.Framework.Application.CQRS.EventHandling;
using Tactical.Framework.Core.Abstractions;

namespace Tactical.Framework.Application.CQRS.CommandHandling;

public abstract class CommandHandler<TCommand> : ICommandHandler<TCommand> where TCommand : ICommand
{
    private readonly IEventBus eventBus;

    protected CommandHandler(IEventBus eventBus)
    {
        this.eventBus = eventBus;
    }

    public abstract Task HandleAsync(TCommand command, CancellationToken cancellationToken);

    public Task PublishAggregatedEvents(IAggregateRoot aggregateRoot)
    {
        return Task.Run(() =>
        {
            foreach (var @event in aggregateRoot.GetAllQueuedEvents())
            {
                PublishEvent(@event);
            }
        });
    }

    public Task PublishEvent<TEvent>(TEvent @event) where TEvent : IEvent
    {
        if (@event is null)
        {
            throw new ArgumentNullException();
        }

        return eventBus.Publish(@event);
    }
}