using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tactical.Framework.Core.Abstractions;

namespace Tactical.Framework.Domain.DomainAbstractions
{
    public class AggregateRoot<TKey> : Entity<TKey>, IAggregateRoot
    {
        public TKey Id { get; set; }
        public IList<IDomainEvent> DomainEvents;

        public IEnumerable<dynamic> GetAllQueuedEvents()
        {
            throw new NotImplementedException();
        }

        public void QueueEvent<TEvent>(TEvent eventToPublish) where TEvent : IEvent
        {
            throw new NotImplementedException();
        }
    }
}
