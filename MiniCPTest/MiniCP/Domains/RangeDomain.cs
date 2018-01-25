using System;
using System.Collections.Generic;

namespace MiniCP
{
    public class RangeDomain : IDomain
    {
        public int LowBound { get; set; }
        public int HighBound { get; set; }
        public int Step { get; set; }

        public int NextValue(int value)
        {
            if (value == int.MinValue)
            {
                return LowBound;
            }

            if (value < LowBound || value > HighBound)
            {
                throw new Exception("Input value out of range");
            }

            if (value + Step > HighBound || value + Step < LowBound)
            {
                return int.MaxValue;
            }

            return value + Step;
        }

        public List<int> Values()
        {
            var values = new List<int>();
            for (var i = LowBound; i <= HighBound; i+=Step)
            {
                values.Add(i);
            }
            return values;
        }

        List<IDomain> IDomain.Remove(int value)
        {
            if(value == this.LowBound){
                this.LowBound += Step;
                return new List<IDomain>{this};
            }

            if(value == this.HighBound){
                this.HighBound -= Step;
                return new List<IDomain> { this };
            }

            return new List<IDomain>{
                new RangeDomain{ LowBound = this.LowBound, HighBound = value-Step },
                new RangeDomain{ LowBound = value+Step, HighBound = this.HighBound}
            };
        }
    }
}