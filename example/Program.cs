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
        public static void func(params int [] arr)
        {
            foreach (int elem in arr)
            {
                Console.WriteLine(elem);
            }
            Console.WriteLine(arr.Average());
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

            BookPersonManager bookManager = new BookPersonManager();
            if (bookManager.ReadNotebook())
            {
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
                            Person _person = new Person(Name, Surname, Date, Gender, PhoneNumber);
                            bookManager.AddPerson(_person);
                            break;
                        case 2:
                            foreach (var elem in bookManager.GetPersonList())
                            {
                                Console.WriteLine($"{elem.Name} {elem.Surname}, {elem.Birthday}, {elem.Age} years old, {elem.Gender},{elem.Phonenumber}");
                            }
                            break;
                        case 3:
                            Console.WriteLine("Search: ");
                            foreach (var elem in bookManager.SelectRequest(Console.ReadLine()))
                            {
                                Console.WriteLine($"{elem.Name} {elem.Surname}, {elem.Birthday}, {elem.Age} years old, {elem.Gender},{elem.Phonenumber}");
                            }
                            break;
                        case 4:
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
            
            //int[] array = new int[] { 1, 2, 3 };
            //func(1,2,3,4);

        }
        
    }
}
