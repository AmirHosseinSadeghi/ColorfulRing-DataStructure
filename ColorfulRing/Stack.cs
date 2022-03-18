using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorfulRing
{
    class Stack:IStack
    {
        public EventHandler<string> Statuse;
        private const int _MaxSize = 15;
        public int[] RingList;
        private int _num;

        public Stack()
        {
            RingList = new int[_MaxSize];
            _num = 0;
        }

        public void Push(int ring)
        {
            if (!IsFull()&&ring!=0)
            {
                RingList[_num] = ring;
                _num += 1;
            }
            else
            {
                Statuse(this, "Parking is Full");
            }
        }

        public int Pop()
        {
            if (IsEmpty())
            {
                Statuse(this, "Stack Is Empty......");
                return 0;
            }
            _num -= 1;
            int result = RingList[_num];
            RingList[_num] = 0;
            return result;
        }

        //public string Display()
        //{
        //    string result = "";
        //    foreach (var ring in RingList)
        //        result += ring + "\n";
        //    return result;
        //}


        public bool IsFull()
        {
            return _num >= _MaxSize;
        }

        public bool IsEmpty()
        {
            return _num <= 0;
        }
        public int Size()
        {
            return _num;
        }
    }
}
