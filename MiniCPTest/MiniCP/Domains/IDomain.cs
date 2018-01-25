using System;
using System.Collections.Generic;

namespace MiniCP
{
    public interface IDomain
    {
        int NextValue(int value);
        List<IDomain> Remove(int value);
        List<int> Values();
    }
}
