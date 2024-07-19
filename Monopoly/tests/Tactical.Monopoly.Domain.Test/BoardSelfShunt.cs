using Tactical.Monopoly.Domain.Boards;

namespace Tactical.Monopoly.Domain.Test
{
    public class BoardSelfShunt
    {
        internal const int DefaultPlayerScore = 500;

        internal readonly Guid playerIdOne = Guid.Parse("6f50d939-b125-4b57-8b13-2b4e8b5a2780");
        internal readonly Guid playerIdTwo = Guid.Parse("b0f77d40-9b9c-4c49-9b87-ec46c4ada57b");
        internal static Board CreateBoard() => new(GetPlayerIds());

        internal static List<Guid> GetPlayerIds() =>
        [
            Guid.Parse("6f50d939-b125-4b57-8b13-2b4e8b5a2780"),
            Guid.Parse("b0f77d40-9b9c-4c49-9b87-ec46c4ada57b"),
            Guid.Parse("0058acd2-1779-45cf-b22e-39efb189d138"),
            Guid.Parse("5d361e95-c6e7-4f86-bcce-99666c5db3d0"),
        ];
    }
}
