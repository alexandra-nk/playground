using BowlingGameKata;
using Xunit;

namespace BowlingGameKataTests
{
    public class FramesTests
    {
        [Fact]
        public void Frames_Roll_RollAddedToOpenFrame()
        {
            //Arrange
            var frames = new Frames();

            //Act
            frames.Add(5);

            //Assert
            Assert.Equal(1, frames.CurrentFrame.Number);
            Assert.Equal(1, frames.Count);
            Assert.Equal(frames.CurrentFrame, frames[0]);
            Assert.Equal(5, frames[0].Score);
            Assert.Single(frames[0].Rolls);
            Assert.Equal(5, frames[0].Rolls[0].PinsRolled);
        }

        [Fact]
        public void Frames_Rolls_RollAddedToCurrentFrame()
        {
            //Arrange
            var frames = new Frames();

            //Act
            frames.Add(5);
            frames.Add(3);
            frames.Add(4);

            //Assert
            Assert.Equal(2, frames.CurrentFrame.Number);
            Assert.Equal(2, frames.Count);
            Assert.Equal(8, frames[0].Score);
            Assert.False(frames[0].IsOpen);
            Assert.Single(frames[1].Rolls);
            Assert.True(frames[1].CanRoll);
        }

        [Fact]
        public void Frames_TwoRollsAndSpare_OneBonusRollAddedToFrameScore()
        {
            //Arrange
            var frames = new Frames();

            //Act
            frames.Add(6);
            frames.Add(4);
            frames.Add(5);

            //Assert
            Assert.Equal(15, frames[0].Score);
        }

        [Fact]
        public void Frames_RollsAndStrike_TwoBonusRollsAddedToFrameScore()
        {
            //Arrange
            var frames = new Frames();

            //Act
            frames.Add(10);
            frames.Add(3);
            frames.Add(7);

            //Assert
            Assert.Equal(20, frames[0].Score);
        }

        [Fact]
        public void Frames_Rolls_FramesTotalScoreContainesAllRolls()
        {
            //Arrange
            var frames = new Frames();

            //Act
            frames.Add(4);
            frames.Add(6);
            frames.Add(3);

            //Assert
            Assert.Equal(16, frames.TotalScore);
            Assert.False(frames[0].IsOpen);
        }
    }
}
