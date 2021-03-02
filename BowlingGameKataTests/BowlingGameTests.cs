using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace BowlingGameKata
{
    public class BowlingGameTests
    {
        [Fact]
        public void BowlingGame_GameFinishedAndRoll_ExceptionThrown()
        {
            //Arrange
            var game = new BowlingGame();
            var rolls = new List<int> { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
            game.RollMany(rolls);
            var expectedMessage = "The game is finished!";

            //Act
            Action act = () => game.Roll(5);

            //Assert
            act.Should().Throw<ArgumentOutOfRangeException>()
                .And
                .Message.Should().ContainEquivalentOf(expectedMessage);
        }

        [Fact]
        public void BowlingGame_Rolls_CorrectCurrentScoreCalculated()
        {
            //Arrange   
            var game = new BowlingGame();
            List<(int Roll, int Score)> rollsWithCurrentScore = new List<(int Roll, int Score)>
            {
                (1, 1), (4, 5), (4, 9), (5, 14), (6, 20), (4, 24), (5, 34),
                (5, 39), (10, 59), (0, 59), (1, 61), (7, 68), (3, 71),
                (6, 83), (4, 87), (10, 107), (2, 111), (8, 127), (6, 133)
            };

            //Act
            foreach ((int Roll, int Score) in rollsWithCurrentScore)
            {
                game.Roll(Roll);
                Assert.Equal(Score, game.TotalScore);
            }
        }

        [Theory]
        [MemberData (nameof(GetRolls))]
        public void BowlingGame_Rolls_CorrectScore((List<int> Rolls, int Score) rollsWithScore)
        {
            //Arrange   
            var game = new BowlingGame();

            //Act
            game.RollMany(rollsWithScore.Rolls);

            //Assert
            Assert.Equal(rollsWithScore.Score, game.TotalScore);
            Assert.True(game.IsFinished);
        }

        public static IEnumerable<object[]> GetRolls()
        {
            yield return new object[]
            {
                (new List<int> {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, 0)
            };

            yield return new object[]
            {
                (new List<int> { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, 20)
            };

            yield return new object[]
            {
                (new List<int> {4, 6, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, 16)
            };

            yield return new object[]
            {
                (new List<int> {10, 3, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, 24)
            };

            yield return new object[]
            {
                (new List<int> {9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, 90)
            };

            yield return new object[]
            {
                (new List<int> {1, 4, 4, 5, 6, 4, 5, 5, 10, 0, 1, 7, 3, 6, 4, 10, 2, 8, 6}, 133)
            };

            yield return new object[]
            {
                (new List<int> {10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10}, 300)
            };
        }
    }
}
