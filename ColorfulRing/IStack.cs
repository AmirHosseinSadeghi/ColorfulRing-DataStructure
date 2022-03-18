using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorfulRing
{
    public interface IStack
    {
        void Push(int ring);
        int Pop();
        bool IsFull();
        bool IsEmpty();
        int Size();
    }
}
