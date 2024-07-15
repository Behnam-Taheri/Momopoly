using Tactical.Framework.Core.Abstractions;

namespace Tactical.Monopoly.Domain.Boards.Events
{
    public record CellBoughtEvent : IEvent
    {
        public CellBoughtEvent()
        {
            PublishedOn = DateTime.Now;
        }
        public Guid Id { get; set; }
        public DateTime? PublishedOn { get; set; }
        public string? Message { get; set; }

    }
}
