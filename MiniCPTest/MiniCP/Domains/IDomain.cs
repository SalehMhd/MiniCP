using System;
using System.Collections.Generic;

namespace MiniCP
{
    public interface IDomain
    {
        int NextValue(int value);
        int Remove(int value);
        List<int> Values();
    }
}
