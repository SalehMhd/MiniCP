using System;
using System.Collections.Generic;
using System.Linq;

namespace MiniCP
{
    public class Variable : IOperand
    {
        public List<IDomain> Domains { get; set; }

        private int lastValue = int.MinValue; 
        private int currentDomainIndex = -1;

        public int NextValue()
        {
            if (Domains == null || !Domains.Any())
            {
                throw new Exception("Initialize Domains");
            }

            if (currentDomainIndex == -1)
            {
                lastValue = Domains[0].NextValue(lastValue);
                currentDomainIndex = 0;
                return lastValue;
            }

            var value = Domains[currentDomainIndex].NextValue(lastValue);
            if (value == int.MaxValue)
            {
                currentDomainIndex++;
                if (currentDomainIndex == Domains.Count)
                {
                    return int.MaxValue;
                }

                lastValue = Domains[currentDomainIndex].NextValue(lastValue);
                return lastValue;
            }

            lastValue = value;
            return value;
           
        }

        public int Value()
        {
            if(lastValue == int.MinValue)
            {
                lastValue = this.NextValue();
            }
            return this.lastValue;
        }

        public List<int> Values()
        {
            var valuesList = new List<int>();

            foreach(var domain in this.Domains)
            {
                valuesList.AddRange(domain.Values());
            }

            return valuesList;
        }

        public void RemoveValue(int value)
        {
            Domains[currentDomainIndex].Remove(value);

            var rangeDomain = (RangeDomain)Domains[currentDomainIndex];
            if( rangeDomain.LowBound > rangeDomain.HighBound )
            {
                Domains.RemoveAt(currentDomainIndex);
            }
        }
    }
}