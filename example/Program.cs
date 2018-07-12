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
                            Console.WriteLine("Date: ");
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
        }
    }
}
