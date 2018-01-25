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
                while(valueSmall != int.MaxValue)
                {
                    var valueBig = Operand2.Value();
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
                while (valueBig != int.MaxValue)
                {
                    var valueSmall = Operand1.Value();
                    if (valueSmall > valueBig)
                    {
                        ((Variable)Operand2).RemoveValue(valueBig);
                    }
                    valueBig = ((Variable)Operand2).NextValue();
                }
            }

       }
    }
}