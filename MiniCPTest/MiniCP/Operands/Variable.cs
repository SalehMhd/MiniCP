using System;
using System.Collections.Generic;
using System.Linq;

namespace MiniCP
{
    public class Variable : Operand
    {
        public List<IDomain> Domains { get; set; }// Check for intervening domains

        private int lastValue = -1; 
        private int currentDomainIndex = -1;

        public int NextValue()
        {
            if (Domains == null || !Domains.Any())
            {
                throw new Exception("Initialize Domains");
            }

            //Add check for range domains (Casting Exception)
            if (lastValue == -1)
            {
                lastValue = ((RangeDomain)Domains[0]).LowBound;
                currentDomainIndex = 0;
                return lastValue;
            }

            if (Domains[currentDomainIndex] is RangeDomain domain)
            {
                var value = domain.NextValue(lastValue);
                if (value == -1)
                {
                    currentDomainIndex++;
                }


            }

            if (lastValue == ((RangeDomain)).HighBound)
            {
                if (currentDomainIndex == Domains.Count - 1)
                {
                    return -1;
                }
                currentDomainIndex++;
            }

            
        }
   }
}