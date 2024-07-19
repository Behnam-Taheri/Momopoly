using Tactical.Framework.Core.Abstractions;

namespace Tactical.Monopoly.Domain.Boards.Exceptions
{
    public class InvalidDiceNumberException(string message) : DomainException(message)
    {
    }

    
}
