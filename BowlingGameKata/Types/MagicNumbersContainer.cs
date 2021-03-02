namespace BowlingGameKata
{
    public static class MagicNumbersHelper
    {
        public static int MaxPinsCount => 10;   
        public static int MinPinsCount => 0;
        public static int MaxFramesCount => 10;
        public static int NumberOfLastNormalFrame => 9;
             
        public static class FrameConst
        {
            public static int RollsCountForStrike => 1;
            public static int MaxRollsCount => 2;
            public static int MaxPinsCount => 10;
        }
            
        public static class TenthFrameConst 
        {
            public static int MaxRollsCount => 3;
            public static int NotStrikeAndNotSpareMaxRollsCount => 2;
            public static int BonusRollsCount => 0;
        }
    }
}
