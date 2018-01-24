using System;
using System.Collections.Generic;

namespace MiniCP
{
    public class Variable<T>
    {
        public Variable(List<IDomain<T>> domains)
        {
        }

        public T Value { get; private set; }
    }
}

