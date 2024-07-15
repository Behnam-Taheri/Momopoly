using Tactical.Framework.Core.Abstractions;

namespace Tactical.Monopoly.Domain.Boards.Exceptions
{
    public class CellHasOwnerException(string message) : DomainException(message)
    {
    }
}
