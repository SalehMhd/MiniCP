using System;
using System.Collections.Generic;

namespace MiniCP
{
    public interface IDomain
    {
        int NextValue(int value);
        void Remove(int value);
        List<int> Values();
    }
}
