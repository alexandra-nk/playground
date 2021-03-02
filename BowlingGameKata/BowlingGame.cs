using System.Collections.Generic;

namespace BowlingGameKata
{
    public class BowlingGame
    {
        public int TotalScore => myFrames.TotalScore;
        public Frames Frames => myFrames;
        public bool IsFinished => myFrames.AllFramesClosed;

        public BowlingGame()
        {
            myFrames = new Frames();
        }

        public void Roll(int pinsCount)
        {
            myFrames.Add(pinsCount);
        }

        public void RollMany(List<int> pinsSets)
        {
            pinsSets.ForEach(pinsSet => Roll(pinsSet));
        }

        public Frame GetFrame(int frameNumber)
        {
            return myFrames[frameNumber - 1];
        }

        private Frames myFrames;
    }
}
