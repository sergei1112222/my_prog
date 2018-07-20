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
        
        public static uint summ (uint a, uint b)
        {
            return a + b;
        }

        static void Main(string[] args)
        {
            void IsEmpty(out string str, string field)
            {
                do
                {
                    Console.WriteLine(field);
                    str = Console.ReadLine();
                } while (str.Length == 0);
            }
            void PrintList(Bidirectionallist<Person> list)
            {
                foreach (var elem in list)
                {
                    Console.WriteLine($"{elem.ID}. {elem.Name} {elem.Surname}, {elem.Birthday}, {elem.Age} years old, {elem.Gender},{elem.Phonenumber}");
                }
            }

            BookPersonManager bookManager = new BookPersonManager();
            if (bookManager.ReadNotebook())
            {
                bool flag = false;
                while (!flag)
                {
                    Console.WriteLine("1. Add person");
                    Console.WriteLine("2. Print notebook");
                    Console.WriteLine("3. Search");
                    Console.WriteLine("4. Delete");
                    Console.WriteLine("5. Exit");
                    int.TryParse(Console.ReadLine(), out int choice);
                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            DateTime Date;
                            char Gender;
                            string Name, Surname;
                            IsEmpty(out Name, "Name: ");
                            IsEmpty(out Surname, "Surname: ");
                            do
                            {
                                Console.WriteLine("Date: ");
                                Date = Convert.ToDateTime(Console.ReadLine());
                            } while (Date > DateTime.Now);
                            do
                            {
                                Console.WriteLine("Gender: ");
                                Gender = Console.ReadLine()[0];
                            } while ((Gender != 'f') && (Gender != 'm'));
                            Console.WriteLine("Phonenumber: ");
                            string PhoneNumber = Console.ReadLine();
                            //Person _person = new Person(Name, Surname, Date, Gender, PhoneNumber);
                            bookManager.AddPerson(Name, Surname, Date, Gender, PhoneNumber);
                            Console.Clear();
                            Console.WriteLine(" ");
                            PrintList(bookManager.GetPersonList());
                            Console.WriteLine(" ");
                            break;
                        case 2:
                            Console.Clear();
                            PrintList(bookManager.GetPersonList());
                            Console.WriteLine(" ");
                            break;
                        case 3:
                            Console.Clear();
                            Console.WriteLine("Search: ");
                            PrintList(bookManager.SelectRequest(Console.ReadLine()));
                            break;
                        case 4:
                            int ID;
                            bool parseFlag = false;
                            Console.WriteLine(" ");
                            Console.WriteLine("ID: ");
                            do
                            {
                                parseFlag = int.TryParse(Console.ReadLine(), out ID);
                                if (!parseFlag)
                                    Console.WriteLine("Incorrect index! Repeat please...");
                            } while (!parseFlag);
                            bookManager.RemovePerson(ID);
                            Console.Clear();
                            PrintList(bookManager.GetPersonList());
                            Console.WriteLine(" ");
                            break;
                        case 5:
                            flag = true;
                            break;
                        default:
                            Console.WriteLine("Incorrect input. Repeat please;");
                            break;
                    }
                }
                bookManager.SaveNotebook();
            }
            else
                Console.WriteLine("Reading from file is failed!");
           


        }
        
    }
}
