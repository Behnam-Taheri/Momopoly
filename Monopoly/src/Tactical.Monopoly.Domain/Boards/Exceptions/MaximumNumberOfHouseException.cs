using Tactical.Framework.Core.Abstractions;

namespace Tactical.Monopoly.Domain.Boards.Exceptions
{
    public class MaximumNumberOfHouseException(string message) : DomainException(message)
    {
    }
}
