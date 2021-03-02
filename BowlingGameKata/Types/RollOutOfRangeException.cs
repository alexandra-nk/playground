using System;

namespace BowlingGameKata
{
    public class RollOutOfRangeException : Exception
    {
        public RollOutOfRangeException( string message) : base(message)
        {

        }
    }
}