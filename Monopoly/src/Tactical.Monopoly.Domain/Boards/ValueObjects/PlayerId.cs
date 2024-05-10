using Tactical.Framework.Domain.DomainAbstractions;

namespace Tactical.Monopoly.Domain.Boards.ValueObjects
{
    public class PlayerId : ValueObject<PlayerId>
    {
        private PlayerId() { }
        public PlayerId(Guid value)
        {
            Value = value;
        }

        public Guid Value { get; private set; }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
