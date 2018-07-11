using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Structure;
using BookPerson;


namespace example
{
	

	class Program
    {
        static void Main(string[] args)
        {
            //Bidirectionallist<int> list = new Bidirectionallist<int>();
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
            /*list.PushTail(1);
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
            Console.WriteLine("Foreach");*/
            
            BookPersonManager bookManager = new BookPersonManager();
            bookManager.AddPerson("John", "Smith", 'm', 23, "12345678");
            bookManager.AddPerson("Trevor", "Clark", 'm', 22, "41234132");
            bookManager.AddPerson("Mike", "Whillams", 'm', 43, "12315");
            Bidirectionallist<Person> list = bookManager.GetPersonList();
            list.PrintList();
            list.PushHead(new Person("Clara", "James", 'f', 32, "03"));
            foreach (var elem in list)
            {
                Console.WriteLine(elem.);
            }
            list.PrintList();
            Console.WriteLine("Press any key to exit ... ");
            Console.ReadKey();
            
            //Console.WriteLine(list.SelectIndexElement("> 100"));
                
        }
    }
}
