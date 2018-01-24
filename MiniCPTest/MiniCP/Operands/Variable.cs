using System;
using System.Collections.Generic;

namespace MiniCP
{
    public class Variable<T> : Operand<T>
    {
        public List<IDomain<T>> Domains { get; set; }
    }
}

