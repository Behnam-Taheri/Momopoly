using Tactical.Framework.Core.Abstractions;

namespace Tactical.Framework.Domain.DomainAbstractions
{
    public class AggregateRoot<TKey> : Entity<TKey>, IAggregateRoot
    {
        public readonly IList<dynamic> _domainEvents = [];
        public IEnumerable<dynamic> GetAllQueuedEvents() => _domainEvents;

        public void QueueEvent<TEvent>(TEvent eventToPublish) where TEvent : IEvent
        {
            _domainEvents.Add(eventToPublish);
        }
    }
}
