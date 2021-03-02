namespace BowlingGameKata
{
    public class TenthFrame : Frame
    {
        public override bool CanRoll => CheckCanRoll();
        public override int BonusRollsCount => MagicNumbersHelper.TenthFrameConst.BonusRollsCount;

        public TenthFrame() : base(MagicNumbersHelper.MaxFramesCount)
        {
        }

        private bool CheckCanRoll()
        {
            if (Rolls.Count == MagicNumbersHelper.TenthFrameConst.NotStrikeAndNotSpareMaxRollsCount && TotalPinsRolled < MagicNumbersHelper.MaxPinsCount)
            {
                return false;
            }

            if (Rolls.Count == MagicNumbersHelper.TenthFrameConst.MaxRollsCount)
            {
                return false;
            }

            return true;
        }
    }
}
