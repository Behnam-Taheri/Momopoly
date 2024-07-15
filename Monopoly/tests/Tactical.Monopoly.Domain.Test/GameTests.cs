using FluentAssertions;
using Tactical.Monopoly.Domain.Boards;
using Tactical.Monopoly.Domain.Boards.Exceptions;

namespace Tactical.Monopoly.Domain.Test
{
    public class GameTests
    {
        private readonly Guid playerIdOne = Guid.Parse("6f50d939-b125-4b57-8b13-2b4e8b5a2780");
        private readonly Guid playerIdTwo = Guid.Parse("b0f77d40-9b9c-4c49-9b87-ec46c4ada57b");
        private const int DefaultPlayerScore = 500;
        private const int FirstCellScore = 280;

        [Fact]
        public void Move_To_Bought_Cell_Score_Should_Be_Decrease()
        {
            var board = CreateBoard();
            board.MovePlayer(playerIdOne, 1);
            board.BuyCell(1, playerIdOne);
            board.MovePlayer(playerIdTwo, 1);

            var actualScore = board.BoardScores.First(x => x.PlayerId == playerIdTwo).Score;

            var exceptedScore = DefaultPlayerScore - FirstCellScore;

            actualScore.Should().Be(exceptedScore);
        }

        [Fact]
        public void Buy_UnBuyable_Cell_Test_Should_Be_Throw_Exception()
        {
            var board = CreateBoard();
            board.MovePlayer(playerIdOne, 5);

            Assert.Throws<NotBuyableCellException>(() => board.BuyCell(5, playerIdOne));
        }

        [Fact]
        public void Buy_Buyable_Cell_With_Owner_Test_Should_Be_Throw_Exception()
        {
            var board = CreateBoard();
            board.MovePlayer(playerIdOne, 1);
            board.BuyCell(1, playerIdOne);
            board.MovePlayer(playerIdTwo, 1);

            Assert.Throws<CellHasOwnerException>(() => board.BuyCell(1, playerIdTwo));
        }

        [Fact]
        public void Buy_Buyable_Cell_Cell_Should_Be_have_OwnerId()
        {
            var board = CreateBoard();
            board.MovePlayer(playerIdOne, 6);
            board.BuyCell(6, playerIdOne);

            board.Cells.First(c => c.Position == 6).OwnerId.Should().Be(playerIdOne);
        }

        [Fact]
        public void Create_a_House_NumberOfHouse_In_Cell_Should_Be_One()
        {
            var board = CreateBoard();
            board.MovePlayer(playerIdOne, 1);
            board.BuyCell(1, playerIdOne);

            board.MovePlayer(playerIdOne, 1);
            board.BuyCell(2, playerIdOne);

            board.CreateHouse(1, playerIdOne);

            board.Cells.First(c => c.Position == 1).NumberOfHouse.Should().Be(1);
        }

        [Fact]
        public void Create_More_Than_Maximum_NumberOfHouse_Test_Should_Be_Throw_Exception()
        {
            var board = CreateBoard();
            board.MovePlayer(playerIdOne, 1);
            board.BuyCell(1, playerIdOne);

            board.MovePlayer(playerIdOne, 1);
            board.BuyCell(2, playerIdOne);

            board.CreateHouse(1, playerIdOne);
            board.CreateHouse(1, playerIdOne);
            board.CreateHouse(1, playerIdOne);

            Assert.Throws<MaximumNumberOfHouseException>(() => board.CreateHouse(1, playerIdOne));
        }

        [Fact]
        public void Create_House_In_Not_Manufacturable_Cell_Test_Should_Be_Throw_Exception()
        {
            var board = CreateBoard();
            board.MovePlayer(playerIdOne, 5);

            Assert.Throws<NotManufacturableCellException>(() => board.CreateHouse(5, playerIdOne));
        }

        [Fact]
        public void Create_House_With_Out_Have_Bought_Related_Cells_Test_Should_Be_Throw_Exception()
        {
            var board = CreateBoard();
            board.MovePlayer(playerIdOne, 1);
            board.BuyCell(1, playerIdOne);

            Assert.Throws<NotBuyAllRelatedCellException>(() => board.CreateHouse(1, playerIdOne));
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