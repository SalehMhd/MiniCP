using System;
namespace MiniCP
{
    public class SmallerThan<T> : IRule
    {
        public Operand<T> Operand1 { get; set; }
        public Operand<T> Operand2 { get; set; }

        public SmallerThan()
        {
        }

        public void Propagate()
        {
            throw new NotImplementedException();
        }
    }
}
