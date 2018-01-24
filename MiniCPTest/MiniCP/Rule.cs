namespace MiniCP
{
    public class Rule
    {
        public object Operand1 { get; set; }
        public object Operand2 { get; set; }
        public IOperation Operation { get; set; }


        public Rule Operand(object operand)
        {
            if (Operand1 == null)
            {
                this.Operand1 = operand;
            }
            else
            {
                this.Operand2 = operand;
            }

            return this;
        }

        public Rule Operator(IOperation operation)
        {
            this.Operation = operation;
        }
    }
}
