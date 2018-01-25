using System;
namespace MiniCP
{
    public interface IDomain
    {
        int NextValue(int value);
    }
}
