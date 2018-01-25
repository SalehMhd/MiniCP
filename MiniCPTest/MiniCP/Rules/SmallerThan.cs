namespace MiniCP
{
    public class SmallerThan : IRule
    {
        public Operand Operand1 { get; set; }
        public Operand Operand2 { get; set; }

        public void Propagate()
        {
            if(Operand1 is Variable) {
                var value  = Operand1.

            }
        }
    }
}
