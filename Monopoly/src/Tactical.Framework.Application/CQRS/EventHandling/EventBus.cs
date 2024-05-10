using Tactical.Framework.Core.Abstractions;

namespace Tactical.Framework.Application.CQRS.EventHandling;

public class EventBus : IEventBus
{
    private readonly IList<object> _subscribers;
    public EventBus()
    {
        _subscribers = new List<object>();
    }

    public Task Publish<TEvent>(TEvent @event) where TEvent : IEvent
    {
        if (@event != null)
        {
            @event.PublishedOn = DateTime.Now;
            FireSubscribers(@event);
        }

        return Task.CompletedTask;
    }

    public void Subscribe<TEvent>(Action<TEvent> eventHandler) where TEvent : IEvent
    {
        _subscribers.Add(eventHandler);
    }

    private void FireSubscribers<TEvent>(TEvent @event) where TEvent : IEvent
    {
        var actions = _subscribers.OfType<Action<TEvent>>().ToList();
        if (actions.Any())
        {
            actions.ForEach(subscriber =>
            {
                subscriber(@event);
                Unsubscribe(subscriber);
            });
        }
    }

    private void Unsubscribe<TEvent>(Action<TEvent> subscriber) where TEvent : IEvent
    {
        _subscribers.Remove(subscriber);
    }
}