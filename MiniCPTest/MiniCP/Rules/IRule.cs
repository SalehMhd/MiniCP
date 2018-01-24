using System;
namespace MiniCP
{
    public interface IRule
    {
        void Propagate();
    }
}
