using Tactical.Framework.Core.Abstractions;

namespace Tactical.Monopoly.Domain.Boards.Events
{
    public record BoardCreatedEvent : IEvent
    {
        public BoardCreatedEvent()
        {
            PublishedOn = DateTime.Now;
        }
        public Guid Id { get; set; }
        public DateTime? PublishedOn { get; set; }
    }

    public record PlayerMovedToJailEvent : IEvent
    {
        public PlayerMovedToJailEvent()
        {
            PublishedOn = DateTime.Now;
            SpecialLogic = "Jail";
        }
        public Guid Id { get; set; }
        public DateTime? PublishedOn { get; set; }
        public short Position { get; set; }
        public string SpecialLogic { get; private set; }
    }
}
