using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BowlingGameKata
{
    public class Frames : IEnumerable<Frame>
    {
        public Frame CurrentFrame => myCurrentFrame;
        public int Count => myFrames.Count;
        public int TotalScore => myFrames.Sum(frame => frame.Score);
        public bool AllFramesClosed => !myFrames.Any(frame => frame.IsOpen);

        public Frames()
        {
            myFrames = new List<Frame>(MagicNumbersHelper.MaxFramesCount);
        }

        public Frame this[int index]
        {
            get { return myFrames[index]; }
        }

        public IEnumerator<Frame> GetEnumerator()
        {
            return myFrames.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void Add(int pinsCount)
        {
            myCurrentFrame = GetCurrentFrame();
            myCurrentFrame.AddRoll(pinsCount);

            UpdateOpenFrames(pinsCount);    
        }

        private Frame GetCurrentFrame()
        {
            var currentFrame = myFrames.Where(frame => frame.CanRoll).FirstOrDefault();
            if (currentFrame != null)
            {
                return currentFrame;
            }

            var newFrame = CreateNewFrame();
            myFrames.Add(newFrame);

            return newFrame;
        }
        
        private void UpdateOpenFrames(int pinsCount)
        {
            if (myFrames.Count == 1)
            {
                return;
            }

            var openFrames = myFrames.Where(x => x.IsOpen == true && x.Number < myCurrentFrame.Number).ToList();
            if (openFrames.Any())
            {
                openFrames.ForEach(frame => frame.UpdateScore(pinsCount));
            }
        }

        private Frame CreateNewFrame()
        {
            var frameNumber = myFrames.Count;
            if (frameNumber >= MagicNumbersHelper.MaxFramesCount)
            {
                throw new ArgumentOutOfRangeException(nameof(frameNumber), "The game is finished!");
            }

            return frameNumber == MagicNumbersHelper.NumberOfLastNormalFrame ? new TenthFrame() : new Frame(myFrames.Count + 1);
        }

        private Frame myCurrentFrame;
        private List<Frame> myFrames;
    }
}