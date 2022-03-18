using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorfulRing
{
    public class Node
    {
        public int ring;
        public Node next;

        public Node(int ring)
        {
            this.ring = ring;
            next = null;
        }

    }

    class StackWithLinkList : IStack
    {
        public EventHandler<string> Statuse;
        private Node Head;
        private int _size;

        public StackWithLinkList()
        {
            _size = 0;
            Head = null;
        }
        public int Pop()
        {
            if (IsEmpty())
            {
                Statuse(this, "Stack is Empty......");
                return 0;
            }
            else if (Head.next == null)
            {
                int result = Head.ring;
                Head = null;
                _size--;
                return result;
            }
            else
            {
                Node temp = Head;
                Node prev = null;
                while (temp.next != null)
                {
                    prev = temp;
                    temp = temp.next;
                }
                int result = temp.ring;
                prev.next = null;
                _size--;
                return result;
            }
        }

        public void Push(int ring)
        {
            Node newNode = new Node(ring);
            if (IsFull())
            {
                Statuse(this, "Stact is Full.......");
            }
            else if (IsEmpty())
            {
                Head = newNode;
            }
            else if (ring != 0)
            {
                Node temp = Head;
                while (temp.next != null)
                {
                    temp = temp.next;
                }

                temp.next = newNode;
                _size++;
            }
        }
        public int[] Rings()
        {
            int[] rings = new int[15];
            Node temp = Head;
            if (temp == null)
                return rings;
            if(temp.next==null)
            {
                rings[0] = temp.ring;
                return rings;
            }
            int i = 0;
            while (temp.next != null && i < 14)
            {
                rings[i] = temp.ring;
                temp = temp.next;
                i++;
            }
            rings[i] = temp.ring;
            return rings;
        }
        public bool IsEmpty()
        {
            return Head == null;
        }

        public bool IsFull()
        {
            return _size >= 30;
        }

        public int Size()
        {
            return _size;
        }
    }
}
