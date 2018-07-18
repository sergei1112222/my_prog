﻿using System;
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
            void PrintList(Bidirectionallist<Person> list)
            {
                int count = 0;
                foreach (var elem in list)
                {
                    Console.WriteLine($"{++count}. {elem.Name} {elem.Surname}, {elem.Birthday}, {elem.Age} years old, {elem.Gender},{elem.Phonenumber}");
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
                            Person _person = new Person(Name, Surname, Date, Gender, PhoneNumber);
                            bookManager.AddPerson(_person);
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
                            int index;
                            bool parseFlag = false;
                            Console.WriteLine(" ");
                            Console.WriteLine("Index: ");
                            do
                            {
                                parseFlag = int.TryParse(Console.ReadLine(), out index);
                                if (!parseFlag)
                                    Console.WriteLine("Incorrect index! Repeat please...");
                                else
                                {
                                    if ((index < 1) || (index > bookManager.Count))
                                    {
                                        Console.WriteLine("Index out of bounds! Repeat input...");
                                    }
                                    /*else
                                    {
                                        bookManager.DeletePerson(index);
                                    }*/
                                }
                                bool var1 = (index < 1) && (index > bookManager.Count);
                                bool var2 = (!parseFlag) || var1;
                            } while ((!parseFlag) || ((index < 1) || (index > bookManager.Count)));
                            bookManager.DeletePerson(index);
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
            
            //int[] array = new int[] { 1, 2, 3 };
            //func(1,2,3,4);

        }
        
    }
}
