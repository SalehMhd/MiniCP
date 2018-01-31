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
            if (Domains == null)
            {
                throw new Exception("Initialize Domains");
            }

            if(!Domains.Any())
            {
                return int.MaxValue;
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
                if (currentDomainIndex >= Domains.Count)
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
            IDomain principleDomain = null;

            foreach(var domain in Domains)
            {
                if (domain.Remove(value) == 1)
                {
                    principleDomain = domain;
                    break;   
                }
            }

            if( (principleDomain as RangeDomain).LowBound > (principleDomain as RangeDomain).HighBound )
            {
                Domains.Remove(principleDomain);
            }
        }
    }
}