﻿using System;
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
            //for (int i = 0; i < 12; i++)
            //{
            //elem[i] = new Bidirectionallist.Element(i);
            //if (i < 6)
            //      list.PushHead(i);
            // else
            //   list.PushTail(i);
            //}
            //Bidirectionallist.Element ins_el = new Bidirectionallist.Element(101);
            list.PushTail(1);
            list.PushTail(2);
            list.PushTail(3);
            list.PushTail(4);
            list.PushTail(5);
            if (list.PushInsert(12, 101))
            {
                Console.WriteLine("Insert successfully;");
            }
            else
                Console.WriteLine("Insert unsuccessfully");
            list.PrintList();
            
            if(list.Remove(12))
            {
                Console.WriteLine("Remove successfully;");
            }
            else
                Console.WriteLine("Remove unsuccessfully");
            list.PrintList();
            Console.WriteLine("Foreach");
            foreach (var elem in list){
                Console.WriteLine(elem.ToString());
            }
            Console.WriteLine(list.SelectIndexElement("> 100"));
                
        }
    }
}
