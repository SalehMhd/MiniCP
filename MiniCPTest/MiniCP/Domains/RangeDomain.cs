using System;
namespace MiniCP
{
    public class RangeDomain<T> : IDomain<T>
    {
        public T LowBound { get; set; }
        public T HighBound { get; set; }
        private T LastValue { get; }


        public Variable<T> Variable
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public T NextValue()
        {
            throw new NotImplementedException();
        }
    }
}
