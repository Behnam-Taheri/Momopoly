using Tactical.Framework.Core.Abstractions;

namespace Tactical.Monopoly.Domain.Boards.Exceptions
{
    public class NotManufacturableCellException(string message) : DomainException(message)
    {
    }

    public class NotBuyAllRelatedCellException(string message) : DomainException(message)
    {
    }
}
