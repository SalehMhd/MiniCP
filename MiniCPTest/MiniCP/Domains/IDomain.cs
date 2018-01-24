using System;
namespace MiniCP
{
    public interface IDomain<T>
    {
        Variable<T> Variable { get; set; }

        T NextValue();
    }
}
