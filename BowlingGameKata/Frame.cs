using System.Collections.Generic;
using System.Linq;

namespace BowlingGameKata
{
    public class Frame
    {
        public List<Roll> Rolls { get; private set; }
        public int Number { get; }
        public int Score
        {
            get => Rolls.Sum(roll => roll.PinsRolled) + myBonusRolls.Sum();
        }

        public virtual bool CanRoll => !(Rolls.Count == MagicNumbersHelper.FrameConst.MaxRollsCount || IsStrike);
        public bool IsStrike => Rolls.Count == MagicNumbersHelper.FrameConst.RollsCountForStrike && Rolls.First().IsStrike;
        public bool IsSpare => Rolls.Count == MagicNumbersHelper.FrameConst.MaxRollsCount && TotalPinsRolled == MagicNumbersHelper.FrameConst.MaxPinsCount;
        public bool IsOpen => (IsStrike || IsSpare) && myBonusRolls.Count < BonusRollsCount;
        public virtual int BonusRollsCount => IsStrike ? 2 : (IsSpare ? 1 : 0);
        public int TotalPinsRolled => Rolls.Sum(r => r.PinsRolled);

        public Frame(int number)
        {
            Number = number;
            Rolls = new List<Roll>();
            myBonusRolls = new List<int>();
        }

        public void AddRoll(int pinsCount)
        {
            if (CanRoll)
            {
                Rolls.Add(new Roll(pinsCount));
            }
            else
            {
                throw new RollOutOfRangeException("No more rolls can be added");
            }
        }

        public void UpdateScore(int pinsCount)
        {
            if (IsOpen)
            {
                myBonusRolls.Add(pinsCount);
            }
        }

        private List<int> myBonusRolls;        
    }
}
