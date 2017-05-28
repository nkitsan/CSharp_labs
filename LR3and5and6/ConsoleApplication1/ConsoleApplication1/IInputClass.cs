using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public interface IInputClass<T>
    {
        void InputArray(T[] t, int n);
    }
}
