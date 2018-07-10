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
            //Bidirectionallist.Element[] elem = new Bidirectionallist.Element[12];
            for (int i = 0; i < 12; i++)
            {
                //elem[i] = new Bidirectionallist.Element(i);
                if (i < 6)
                    list.PushHead(i);
                else
                    list.PushTail(i);
            }
            //Bidirectionallist.Element ins_el = new Bidirectionallist.Element(101);
            list.PushInsert(12, 101);
            list.PrintList();
            list.Remove(12);
            list.PrintList();
            Console.WriteLine(list.SelectIndexElement("> 100"));
                
        }
    }
}
