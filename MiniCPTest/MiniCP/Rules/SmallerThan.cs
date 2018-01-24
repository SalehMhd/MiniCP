using System;
namespace MiniCP
{
    public class SmallerThan<T> : IRule
    {
        public Operand<T> Operand1 { get; set; }
        public Operand<T> Operand2 { get; set; }

        public void Propagate()
        {
            if(Operand1 is Variable<T>) {
                var operand1Var = Operand1 as Variable<T>;



            }
        }
    }
}
