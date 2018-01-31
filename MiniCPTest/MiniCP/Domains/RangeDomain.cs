using System;
using System.Collections.Generic;

namespace MiniCP
{
    public class RangeDomain : IDomain
    {
        public int LowBound { get; set; }
        public int HighBound { get; set; }

        public int NextValue(int value)
        {
            if (value < LowBound)
            {
                return LowBound;
            }

            if(value >= HighBound)
            {
                return int.MaxValue;
            }

            return value + 1;
        }

        public List<int> Values()
        {
            var values = new List<int>();
            for (var i = LowBound; i <= HighBound; i+=1)
            {
                values.Add(i);
            }
            return values;
        }

        public int Remove(int value)
        {
            if (value == this.LowBound)
            {
                this.LowBound += 1;
                return 1;
            }

            if (value == this.HighBound)
            {
                this.HighBound -= 1;
                return 1;
            }

            if(value > LowBound && value < HighBound)
                throw new Exception("value within the range, could not be removed");

            return 0;
        }
    }
}