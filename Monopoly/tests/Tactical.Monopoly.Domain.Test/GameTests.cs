using FluentAssertions;
using Tactical.Monopoly.Domain.Boards;

namespace Tactical.Monopoly.Domain.Test
{
    public class GameTests
    {
        private readonly Guid playerIdOne = Guid.Parse("6f50d939-b125-4b57-8b13-2b4e8b5a2780");
        private readonly Guid playerIdTwo = Guid.Parse("b0f77d40-9b9c-4c49-9b87-ec46c4ada57b");
        private const int DefaultPlayerScore = 500;
        private const int FirstCellScore = 280;

        [Fact]
        public void Move_To_Bought_Cell_Score_Must_Be_Decrease()
        {
            var board = CreateBoard();
            board.MovePlayer(playerIdOne, 1);
            board.BuyCell(1, playerIdOne);
            board.MovePlayer(playerIdTwo, 1);

            var actualScore = board.BoardScores.First(x => x.PlayerId == playerIdTwo).Score;

            var exceptedScore = DefaultPlayerScore- FirstCellScore;

            actualScore.Should().Be(exceptedScore);
        }

        [Fact]
        public void Check_Minus_Score()
        {

        }

        [Fact]
        public void Check_Loser()
        {

        }


        private static Board CreateBoard() => new(GetPlayerIds());

        private static List<Guid> GetPlayerIds() =>
        [
            Guid.Parse("6f50d939-b125-4b57-8b13-2b4e8b5a2780"),
            Guid.Parse("b0f77d40-9b9c-4c49-9b87-ec46c4ada57b"),
            Guid.Parse("0058acd2-1779-45cf-b22e-39efb189d138"),
            Guid.Parse("5d361e95-c6e7-4f86-bcce-99666c5db3d0"),
        ];

    }
}