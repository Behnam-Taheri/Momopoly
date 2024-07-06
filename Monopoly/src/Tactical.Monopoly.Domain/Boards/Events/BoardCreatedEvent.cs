using Tactical.Framework.Core.Abstractions;

namespace Tactical.Monopoly.Domain.Boards.Events
{
    public record BoardCreatedEvent : IEvent
    {
        public Guid Id { get; set; }
        public DateTime? PublishedOn { get; set; }
    }
}
