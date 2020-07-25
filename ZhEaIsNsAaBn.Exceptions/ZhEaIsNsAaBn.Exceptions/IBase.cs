using System;
using System.Collections.Generic;
using System.Text;

namespace ZhEaIsNsAaBn.Exceptions
{
    public interface IBase<T>
    {
            T this[long childID] { get; }

            bool Equals(object obj);
            int GetHashCode();
            bool isa(T super);
    }
    public interface IBase
    {
        IBase this[long childID] { get; }

            bool Equals(object obj);
            int GetHashCode();
            bool isa(IBase super);
    }
}
