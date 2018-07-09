using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Smarteck.Structure;

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
	

	class Program
    {
        static void Main(string[] args)
        {
			Bidirectionallist list = new Bidirectionallist();
            Element [] elem = new Element[12];
            for (int i = 0; i < 12; i++)
            {
                elem[i] = new Element(i);
                if (i < 6)
                    list.PushHead(elem[i]);
                else
                    list.PushTail(elem[i]);
            }
            Element ins_el = new Element(101);
            list.PushInsert("12", ins_el);
            list.printList();
            list.remove("12");
            list.printList();
            Console.WriteLine(list.selectIndexElement("> 100"));
                
        }
    }
}
