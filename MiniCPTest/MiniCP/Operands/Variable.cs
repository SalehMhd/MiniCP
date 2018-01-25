using System;
using System.Collections.Generic;
using System.Linq;

namespace MiniCP
{
    public class Variable : IOperand
    {
        public List<IDomain> Domains { get; set; }// Check for intervening domains

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
                if (currentDomainIndex == Domains.Count - 1)
                {
                    return int.MaxValue;
                }

                lastValue = Domains[currentDomainIndex].NextValue(lastValue);
                return lastValue;
            }

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

        public void RemoveValue(int value)
        {
            var domainsList = Domains[currentDomainIndex].Remove(value);
            Domains.AddRange(domainsList);
        }
    }
}