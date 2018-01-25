using System;
namespace MiniCP
{
    public class Constant : IOperand
    {
        private int value;

        public Constant(int inValue)
        {
            this.value = inValue;
        }

        public int Value()
        {
            throw new NotImplementedException();
        }
    }
}
