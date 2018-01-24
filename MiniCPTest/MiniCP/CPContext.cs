using System;
using System.Collections.Generic;

namespace MiniCP
{
    public class CPContext
    {
        private List<IRule> Rules { get; set; }

        public void Add(IRule rule) {
            this.Rules.Add(rule);
        }

        public void Evaluate()
        {

            foreach(var rule in this.Rules)
            {
                rule.Propagate();
            }


        }
    }
}
