using System;
namespace MiniCP
{
    public class RangeDomain : IDomain
    {
        public int LowBound { get; set; }
        public int HighBound { get; set; }
        public int Step { get; set; }

        public int NextValue(int value)
        {
            if (value < LowBound || value > HighBound)
            {
                throw new Exception("Input value out of range");
            }

            if (value + Step > HighBound || value + Step < LowBound)
            {
                return -1;
            }

            return value + Step;
        }
    }
}