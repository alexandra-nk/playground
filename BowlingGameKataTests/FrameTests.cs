using FluentAssertions;
using System;
using Xunit;

namespace BowlingGameKata
{
    public class FrameTests
    {
        [Fact]
        public void Frame_Roll_RollAdded()
        {
            //Arrange
            var frame = new Frame(1);

            //Act
            frame.AddRoll(4);

            //Assert
            Assert.Single(frame.Rolls);
            Assert.Equal(4, frame.Rolls[0].PinsRolled);
            Assert.True(frame.CanRoll);
            Assert.Equal(4, frame.Score);
        }

        [Fact]
        public void Frame_Rolls10Pins_IsStrike()
        {
            //Arrange
            var frame = new Frame(1);

            //Act
            frame.AddRoll(10);

            //Assert
            Assert.True(frame.IsStrike);
        }

        [Fact]
        public void Frame_Roll4And6Pins_IsSpare()
        {
            //Arrange
            var frame = new Frame(1);

            //Act
            frame.AddRoll(4);
            frame.AddRoll(6);
            
            //Assert
            Assert.True(frame.IsSpare);
        }

        [Fact]
        public void Frame_Rolls_Max2RollsAllowed()
        {
            //Arrange
            var frame = new Frame(1);   
            frame.AddRoll(4);
            frame.AddRoll(3);

            //Act
            Action act = () => frame.AddRoll(3);

            //Assert
            var expectedMessage = "No more rolls can be added";
            Assert.Equal(4, frame.Rolls[0].PinsRolled);
            Assert.Equal(3, frame.Rolls[1].PinsRolled);
            act.Should().Throw<RollOutOfRangeException>()
                .And
                .Message.Should().ContainEquivalentOf(expectedMessage);
            Assert.False(frame.CanRoll);
            Assert.Equal(7, frame.Score);
            Assert.False(frame.IsSpare);
            Assert.False(frame.IsStrike);
        }

        [Fact]
        public void Frame_RollAndStrike_NoMoreRollsAllowed()
        {   
            //Arrange
            var frame = new Frame(8);
            frame.AddRoll(10);

            //Act
            Action act = () => frame.AddRoll(3);

            //Assert
            var expectedMessage = "No more rolls can be added";
            Assert.Single(frame.Rolls);
            Assert.Equal(10, frame.Rolls[0].PinsRolled);
            act.Should().Throw<RollOutOfRangeException>()
                .And
                .Message.Should().ContainEquivalentOf(expectedMessage);
            Assert.False(frame.CanRoll);
            Assert.Equal(10, frame.Score);
            Assert.True(frame.IsStrike);
        }
    }
}
