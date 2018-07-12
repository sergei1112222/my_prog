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
            bool flag = false;
            while (!flag)
            {
                Console.WriteLine("1. Add person");
                Console.WriteLine("2. Print notebook");
                Console.WriteLine("3. Search");
                Console.WriteLine("4. Exit");
                int choice = 0;
                int.TryParse(Console.ReadLine(), out choice);
                switch (choice)
                {
                    case 1:
                        {
                            Console.WriteLine("Name: ");
                            string Name = Console.ReadLine();
                            Console.WriteLine("Surname: ");
                            string Surname = Console.ReadLine();
                            Console.WriteLine("Date: ");s
                            string Date = Console.ReadLine();
                            Console.WriteLine("Gender: ");
                            char Gender = Console.ReadLine()[0];
                            Console.WriteLine("Age: ");
                            int age;
                            int.TryParse(Console.ReadLine(), out age);
                            Console.WriteLine("Phonenumber: ");
                            string PhoneNumber = Console.ReadLine();
                            bookManager.AddPerson(Name, Surname, Date, Gender, age, PhoneNumber);
                            break;
                        }
                    case 2:
                        {
                            foreach (var elem in bookManager.GetPersonList())
                            {
                                Console.WriteLine(elem.Name + ' ' 
                                    + elem.Surname + ", " 
                                    + elem.Birthday + ", " 
                                    + elem.Age.ToString() + " years old, " 
                                    + elem.Gender + ", " + elem.Phonenumber);
                            }
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Search: ");
                            foreach (var elem in bookManager.SelectRequest(Console.ReadLine()))
                            {
                                Console.WriteLine(elem.Name + ' '
                                    + elem.Surname + ", "
                                    + elem.Birthday + ", "
                                    + elem.Age.ToString() + " years old, "
                                    + elem.Gender + ", " + elem.Phonenumber);
                            }
                            break;
    
                        }
                    case 4:
                        {
                            flag = true;
                            break;
                            
                        }
                }
            }
            bookManager.SaveNotebook();
            /*bookManager.AddPerson("John", "Smith","12.06.1996" ,'m', 23, "12345678");
            bookManager.AddPerson("Trevor", "Clark", "11.06.1996", 'm', 22, "41234132");
            bookManager.AddPerson("Mike", "Whillams", "13.06.1996", 'm', 43, "12315");

            bookManager.AddPerson("Clara", "James", "14.06.1996", 'f', 32, "03");
            Bidirectionallist<Person> list = bookManager.SelectRequest("v");
            list.PushHead(new Person("Sara", "Parker", "15.06.1996", 'f', 44, "8800"));
            Console.WriteLine("Out for List");
            foreach (var elem in list)
            {
                Console.WriteLine(elem.Name + ' ' + elem.Surname + ", " + elem.Birthday + ", " + elem.Age.ToString() + " years old, " + elem.Gender + ", phone number - " + elem.Phonenumber);
            }
            Console.WriteLine("Out of bookManager");
            foreach(var elem in bookManager.GetPersonList())
            {
                Console.WriteLine(elem.Name + ' ' + elem.Surname + ", " + elem.Age.ToString() + " years old, " + elem.Gender + ", phone number - " + elem.Phonenumber);
            }
            Console.WriteLine("Press any key to exit ... ");
            Console.ReadKey();
            */
            //Console.WriteLine(list.SelectIndexElement("> 100"));

        }
    }
}
