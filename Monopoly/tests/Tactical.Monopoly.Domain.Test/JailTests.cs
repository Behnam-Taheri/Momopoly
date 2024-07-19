using FluentAssertions;

namespace Tactical.Monopoly.Domain.Test
{
    public class JailTests : BoardSelfShunt
    {
        private const int SixthCellScore = 220;
        private const int JailPrice = 80;

        [Fact]
        public void Move_Player_To_Jail_If_Player_Accept_Pay_Player_Score_Should_Be_Decrease()
        {
            var board = CreateBoard();
            board.MovePlayer(playerIdOne, 6);
            board.BuyCell(6, playerIdOne);
            board.MovePlayer(playerIdOne, 6);

            board.SendPlayerToJail(playerIdOne, false);

            var expected = DefaultPlayerScore - SixthCellScore - JailPrice;

            var actual = board.BoardScores.First(x => x.PlayerId == playerIdOne).Score;

            actual.Should().Be(expected);
        }

        [Fact]
        public void Move_Player_To_Jail_If_Player_Deny_Pay_Player_Score_Should_Not_Be_Change()
        {

        }

        [Fact]
        public void Move_Player_To_Jail_If_Player_Deny_Pay_Player_Should_Be_Freeze()
        {

        }

        [Fact]
        public void Move_Player_To_Jail_If_Player_Does_Not_Have_Any_Asset_Player_Should_Be_Lose()
        {

        }
    }
}
