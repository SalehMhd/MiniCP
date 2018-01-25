using System;
using System.Collections.Generic;

namespace MiniCP
{
    public class CPContext
    {
        private List<IRule> Rules { get; set; }
        private List<Variable> Variables { get; set; }

        public void Add(IRule rule) {
            this.Rules.Add(rule);
        }

        public void Add(Variable variable)
        {
            this.Variables.Add(variable);
        }

        public Dictionary<Variable, List<int>> Evaluate()
        {
            foreach(var rule in this.Rules)
            {
                rule.Propagate();
            }

            var assignments = new Dictionary<Variable, List<int>>();

            foreach(var variable in this.Variables)
            {
                var valuesList = new List<int>();
                foreach(var domain in variable.Domains)
                {
                    valuesList.AddRange(domain.Values());
                }
                assignments.Add(variable, valuesList);
            }

            return assignments;
        }
    }
}
