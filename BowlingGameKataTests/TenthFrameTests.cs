using BowlingGameKata;
using FluentAssertions;
using System;
using Xunit;

namespace BowlingGameKataTests
{
    public class TenthFrameTests
    {
        [Fact]
        public void TenthFrame_Rolls_CorrectScoreReturned()
        {
            //Arrange   
            var tenthFrame = new TenthFrame();

            //Act
            tenthFrame.AddRoll(10);
            tenthFrame.AddRoll(10);
            tenthFrame.AddRoll(10);
            
            //Assert
            Assert.Equal(30, tenthFrame.Score);
            Assert.Equal(10, tenthFrame.Number);

        }

        [Fact]
        public void TenthFrame_Strike_TwoExtraRollsAllowed()
        {
            //Arrange
            var frame = new TenthFrame();
            frame.AddRoll(10);

            //Act
            frame.AddRoll(3);
            frame.AddRoll(3);
            Action act = () => frame.AddRoll(4);

            //Assert
            var expectedMessage = "No more rolls can be added";

            act.Should().Throw<RollOutOfRangeException>()
                .And
                .Message.Should().ContainEquivalentOf(expectedMessage);
        }

        [Fact]
        public void TenthFrame_MaxRollsCountReached_CanRollIsFalse()
        {
            //Arrange
            var frame = new TenthFrame();
            frame.AddRoll(10);

            //Act
            frame.AddRoll(3);
            frame.AddRoll(3);

            //Assert
            Assert.False(frame.CanRoll);
        }

        [Fact]
        public void TenthFrame_Spare_OneExtraRollAllowed()
        {
            //Arrange
            var frame = new TenthFrame();
            frame.AddRoll(4);
            frame.AddRoll(6);

            //Act
            frame.AddRoll(3);
            Action act = () => frame.AddRoll(5);

            //Assert
            var expectedMessage = "No more rolls can be added";

            act.Should().Throw<RollOutOfRangeException>()
                .And
                .Message.Should().ContainEquivalentOf(expectedMessage);

        }
    }
}
