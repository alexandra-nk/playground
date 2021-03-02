using System;

namespace BowlingGameKata
{
    public class Roll
    {
        public int PinsRolled { get; }

        public bool IsStrike => PinsRolled == MagicNumbersHelper.MaxPinsCount;

        public Roll(int pinsCount)
        {
            if (pinsCount > MagicNumbersHelper.MaxPinsCount || pinsCount < MagicNumbersHelper.MinPinsCount)
            {
                throw new ArgumentOutOfRangeException(nameof(pinsCount), "Not allowed number of pins");
            }

            PinsRolled = pinsCount;
        }
    }
}
