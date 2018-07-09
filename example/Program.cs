using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

/*
namespace Acme.Collections
{
    public class Stack
    {
        Entry top;
        public void Push(object data)
        {
            top = new Entry(top, data);
        }
        public object Pop()
        {
            if (top == null) throw new InvalidOperationException();
            object result = top.data;
            top = top.next;
            return result;
        }
        class Entry
        {
            public Entry next;
            public object data;
            public Entry(Entry next, object data)
            {
                this.next = next;
                this.data = data;
            }
        }
    }
}*/
namespace example
{
    using ACme.Collections;
    class Program
    {
        static void Main(string[] args)
        {
            BidirectionalList list = new BidirectionalList();
            element [] elem = new element[12];
            for (int i = 0; i < 12; i++)
            {
                elem[i] = new element(i);
                if (i < 6)
                    list.push_head(elem[i]);
                else
                    list.push_tail(elem[i]);
            }
            element ins_el = new element(101);
            list.push_insert("12", ins_el);
            list.printList();
            list.remove("12");
            list.printList();
            Console.WriteLine(list.selectIndexelement("> 100"));
                
        }
    }
}
