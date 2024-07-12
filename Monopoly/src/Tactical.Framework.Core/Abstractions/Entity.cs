namespace Tactical.Framework.Core.Abstractions
{
    public class Entity<TKey>
    {
        public TKey Id { get; protected set; }
    }
}
