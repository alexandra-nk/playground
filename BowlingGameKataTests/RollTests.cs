using FluentAssertions;
using System;
using Xunit;

namespace BowlingGameKata
{
    public class RollTests
    {
        [Fact]
        public void Roll_PlayerRolls_Max10PinsCannBeRolled()
        {
            //Arrange
            var expectedMessage = "Not allowed number of pins";

            //Act
            Action act = () => new Roll(11);
            
            //Assert
            act.Should().Throw<ArgumentOutOfRangeException>()
                .And
                .Message.Should().ContainEquivalentOf(expectedMessage);

            //Alternativ
            //var exception = Assert.Throws<ArgumentOutOfRangeException>(() => game.Roll(11));
            //Assert.Contains(expectedExeptionMessage, exception.Message);
        }

        [Fact]
        public void Roll_PlayerRolls_NoMinusPinsCanBeRolled()
        {
            //Arrange   
            var expectedExeptionMessage = "Not allowed number of pins";

            //Act
            Action act = () => new Roll(-1);

            //Assert
            act.Should().Throw<ArgumentOutOfRangeException>()
                .And
                .Message.Should().ContainEquivalentOf(expectedExeptionMessage);
        }
    }
}
    