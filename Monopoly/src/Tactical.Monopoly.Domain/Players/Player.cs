using Tactical.Framework.Domain.DomainAbstractions;

namespace Tactical.Monopoly.Domain.Players
{
    public class Player : AggregateRoot<Guid>
    {
        public string Name { get; set; } = null!;
    }
}
