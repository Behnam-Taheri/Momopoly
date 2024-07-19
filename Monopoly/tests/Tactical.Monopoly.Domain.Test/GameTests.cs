using FluentAssertions;
using Tactical.Monopoly.Domain.Boards;
using Tactical.Monopoly.Domain.Boards.Enums;
using Tactical.Monopoly.Domain.Boards.Exceptions;
using Tactical.Monopoly.Domain.Boards.ValueObjects;

namespace Tactical.Monopoly.Domain.Test
{
    public class GameTests: BoardSelfShunt
    {
       
        private const int FirstCellScore = 280;
        private const int SecondCellScore = 280;
        private const int FirstCellHouseCost = 80;
        private const int MaxNumberOfHouse = 3;
        private const int StartReward = 200;


        [Fact]
        public void Create_Invalid_Dice_Number_Test_Should_Be_Throw_Exception()
        {
            var invalidDiceNumber = 8;
            var board = CreateBoard();
            Assert.Throws<InvalidDiceNumberException>(() => board.MovePlayer(playerIdOne, invalidDiceNumber));
        }

        [Fact]
        public void Create_Valid_Dice_Number_Player_Should_Be_Move()
        {
            short validDiceNumber = 1;
            var board = CreateBoard();
            board.MovePlayer(playerIdOne, validDiceNumber);
            board.Cells.First(x => x.Position == validDiceNumber).PlayerIds.Should().Contain(new PlayerId(playerIdOne));
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
        public void Buy_Buyable_Cell_Score_Should_Be_Decrease()
        {
            var sixthCellCost = 220;
            var board = CreateBoard();
            board.MovePlayer(playerIdOne, 6);
            board.BuyCell(6, playerIdOne);

            var expected = DefaultPlayerScore - sixthCellCost;

            var actual = board.BoardScores.First(x => x.PlayerId == playerIdOne).Score;

            actual.Should().Be(expected);
        }

        [Fact]
        public void Move_To_Bought_Cell_Score_Should_Be_Decrease()
        {
            var board = CreateBoard();
            board.MovePlayer(playerIdOne, 1);
            board.BuyCell(1, playerIdOne);
            board.MovePlayer(playerIdTwo, 1);

            var actualScore = board.BoardScores.First(x => x.PlayerId == playerIdTwo).Score;

            var firstCellPassingPrice = 28;
            var exceptedScore = DefaultPlayerScore - firstCellPassingPrice;

            actualScore.Should().Be(exceptedScore);
        }

        [Fact]
        public void Create_a_House_NumberOfHouse_In_Cell_Should_Be_One()
        {
            var board = CreateBoard();
            board.MovePlayer(playerIdOne, 1);
            board.BuyCell(1, playerIdOne);

            board.MovePlayer(playerIdOne, 2);
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

            board.MovePlayer(playerIdOne, 2);
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
        public void Player_Will_Finish_First_Loop_After_Pass_Start_Cell_Player_Score_Should_Add_200_Scores()
        {
            var board = CreateBoard();
            board.MovePlayer(playerIdOne, 1);
            board.MovePlayer(playerIdOne, 6);
            board.MovePlayer(playerIdOne, 6);
            board.MovePlayer(playerIdOne, 6);
            board.MovePlayer(playerIdOne, 6);
            board.MovePlayer(playerIdOne, 3);

            var exceptedScore = DefaultPlayerScore + StartReward;

            var actualScore = board.BoardScores.First(x => x.PlayerId == playerIdOne).Score;

            actualScore.Should().Be(exceptedScore);

        }

        [Fact]
        public void Calculate_Player_Score_After_Finish_First_Loop()
        {
            var board = CreateBoard();
            board.MovePlayer(playerIdOne, 1);
            board.BuyCell(1, playerIdOne);

            board.MovePlayer(playerIdOne, 6);
            board.MovePlayer(playerIdOne, 6);
            board.MovePlayer(playerIdOne, 6);
            board.MovePlayer(playerIdOne, 6);
            board.MovePlayer(playerIdOne, 3);

            var exceptedScore = DefaultPlayerScore - FirstCellScore + StartReward;

            var actualScore = board.BoardScores.First(x => x.PlayerId == playerIdOne).Score;

            actualScore.Should().Be(exceptedScore);

        }

       // [Fact(DisplayName = "باخت با منفی شدن امتیاز")]
        [Fact]
        public void Create_Cell_With_Maximum_Number_Of_House_Player_Rich_With_Out_Any_Asset_And_Not_Enough_Score_Player_Should_Be_Lose()
        {
            var board = CreateCellWithMaximumNumberOfHouse();
            var exceptedScore = DefaultPlayerScore - FirstCellScore + StartReward - SecondCellScore - (FirstCellHouseCost * MaxNumberOfHouse);
            short exceptedPosition = 2;

            var actualScore = board.BoardScores.First(x => x.PlayerId == playerIdOne);
            var actualPosition = board.Cells.First(x => x.PlayerIds.Any(p => p.Value == playerIdOne)).Position;

            actualScore.Score.Should().Be(exceptedScore);
            actualScore.PlayerState.Should().Be(PlayerState.Lose);
            actualPosition.Should().Be(exceptedPosition);
        }


        [Fact]
        public void Create_Negative_Score_With_Some_Assets_Player_Mortgage_a_Cell_Player_Should_Be_Active()
        {
            var board = CreateCellWithMaximumNumberOfHouse();

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


        private Board CreateCellWithMaximumNumberOfHouse()
        {
            var board = CreateBoard();
            board.MovePlayer(playerIdOne, 1);
            board.BuyCell(1, playerIdOne);

            board.MovePlayer(playerIdOne, 6);
            board.MovePlayer(playerIdOne, 6);
            board.MovePlayer(playerIdOne, 6);
            board.MovePlayer(playerIdOne, 6);

            board.MovePlayer(playerIdOne, 1);
            board.BuyCell(2, playerIdOne);

            board.CreateHouse(1, playerIdOne);
            board.CreateHouse(1, playerIdOne);
            board.CreateHouse(1, playerIdOne);

            return board;
        }

    }
}