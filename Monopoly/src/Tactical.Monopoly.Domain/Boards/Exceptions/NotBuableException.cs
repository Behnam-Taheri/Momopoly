using Tactical.Framework.Core.Abstractions;

namespace Tactical.Monopoly.Domain.Boards.Exceptions
{
    public class NotBuyableCellException(string message) : DomainException(message)
    {
    }
}
