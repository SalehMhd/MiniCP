namespace MiniCP
{
    public class SmallerThan : IRule
    {
        public IOperand Operand1 { get; set; }
        public IOperand Operand2 { get; set; }

        public void Propagate()
        {
            if(Operand1 is Variable) {
                var valueSmall = ((Variable)Operand1).NextValue();
                var valueBig = Operand2.Value();

                while(valueSmall != int.MaxValue)
                {
                    if (valueSmall > valueBig)
                    {
                        ((Variable)Operand1).RemoveValue(valueSmall);
                    }
                    valueSmall = ((Variable)Operand1).NextValue();
                }
            }

            if (Operand2 is Variable)
            {
                var valueBig = ((Variable)Operand2).NextValue();
                var valueSmall = Operand1.Value();

                while (valueBig != int.MaxValue)
                {
                    if (valueSmall >= valueBig)
                    {
                        ((Variable)Operand2).RemoveValue(valueBig);
                    }
                    valueBig = ((Variable)Operand2).NextValue();
                }
            }

       }
    }
}