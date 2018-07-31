using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using PersonNotebook.Common;
using PersonNotebook;
using PersonNotebook.Authorization.Authorizator;
using PersonNotebook.Authorization;


namespace PersonNotebook
{
    

    class Program
    {
        private static BookPersonManager bookManager;
        
        private static void Initialize()
        {
            bookManager = new BookPersonManager(new Authorizator());
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
                    Console.WriteLine($"{elem.Id}. {elem.Name} {elem.Surname}, {elem.Birthday}, {elem.Age} years old, {elem.Gender},{elem.Phonenumber}");
                }
            }
            bool flagLogin = false;
            Initialize();
            while (!flagLogin)
            {
                string uLogin;
                string uPass;
                
                Console.WriteLine("1. Log in");
                Console.WriteLine("2. Sign up");
                Console.WriteLine("3. Exit.");
                int.TryParse(Console.ReadLine(), out int logChoice);
                switch (logChoice)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Authorization: ");
                        Console.WriteLine(" ");
                        IsEmpty(out uLogin, "Login: ");
                        IsEmpty(out uPass, "Password: ");
                        //User u = new User(uLogin, uPass);
                        try
                        {
                            bookManager.Authorization(uLogin, uPass);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Registration: ");
                        Console.WriteLine(" ");
                        IsEmpty(out uLogin, "Login: ");
                        IsEmpty(out uPass, "Password: ");
                        try
                        {
                            Role newUserRole;
                            if (bookManager.UserCount == 0)
                            {
                                newUserRole = Role.Admin;
                                Console.WriteLine("You are admin, becouse you first user");
                            } 
                            else
                                newUserRole = Role.User;
                            bookManager.Registration(uLogin, uPass, newUserRole);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case 3:
                        flagLogin = true;
                        break;
                    default:

                        break;
                }
                if (bookManager.CurrentUser != null)
                {
                    
                        bool flag = false;


                        while (!flag)
                        { 
                            Console.WriteLine("1. Add person");
                            Console.WriteLine("2. Print notebook");
                            Console.WriteLine("3. Search");
                            Console.WriteLine("4. Delete");
                            Console.WriteLine("5. Add admin account");
                            Console.WriteLine("6. Print user list");
                            Console.WriteLine("7. Delete user");
                            Console.WriteLine("8. Set user status");
                            Console.WriteLine("9. Exit");
                            int.TryParse(Console.ReadLine(), out int choice);
                            switch (choice)
                            {
                                case 1:
                                    Console.WriteLine(" ");
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
                                    Console.WriteLine(" ");
                                    Console.WriteLine("Search: ");
                                    PrintList(bookManager.SelectRequest(Console.ReadLine()));
                                    break;
                                case 4:
                                    int ID;
                                    bool parseFlag = false;
                                    Console.Clear();
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
                                    if (bookManager.CurrentUser.UserRole == Role.Admin)
                                    {
                                        Console.Clear();
                                        IsEmpty(out uLogin, "Login: ");
                                        IsEmpty(out uPass, "Password: ");
                                        try
                                        {
                                            bookManager.Registration(uLogin, uPass, Role.Admin);
                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine(e.Message);
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Access denied!");
                                    }
                                    break;
                                case 6:
                                    if (bookManager.CurrentUser.UserRole == Role.Admin)
                                    {
                                        Console.Clear();
                                        foreach (var elem in bookManager.GetUserList())
                                        {
                                            Console.WriteLine($"{elem.Id}. {elem.Login}, {elem.UserRole}");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Access denied!");
                                    }
                                    break;
                                case 7:
                                    if (bookManager.CurrentUser.UserRole == Role.Admin)
                                    { 
                                        Console.Clear();
                                        Console.WriteLine(" ");
                                        Console.WriteLine("ID: ");
                                        do
                                        {
                                            parseFlag = int.TryParse(Console.ReadLine(), out ID);
                                            if (!parseFlag)
                                                Console.WriteLine("Incorrect index! Repeat please...");
                                        } while (!parseFlag);
                                        if (ID == bookManager.CurrentUser.Id)
                                        {
                                            Console.WriteLine("You cannot delete yourself! Ask another admin to do this =))");
                                        }
                                        else
                                        {
                                            bookManager.RemoveUser(ID);
                                            Console.Clear();
                                            foreach (var elem in bookManager.GetUserList())
                                            {
                                                Console.WriteLine($"{elem.Id}. {elem.Login}, {elem.UserRole}");
                                            }
                                            Console.WriteLine(" ");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Access denied!");
                                    }
                                    break;
                                case 8:
                                    if (bookManager.CurrentUser.UserRole == Role.Admin)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Level up user");
                                        Console.WriteLine(" ");
                                        IsEmpty(out uLogin, "Login: ");
                                        try
                                        {
                                            bookManager.SetAdmin(uLogin);
                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine(e.Message);
                                        }

                                    }
                                    else
                                    {
                                        Console.WriteLine("Access denied!");
                                    }
                                    break;
                                case 9:
                                    flag = true;
                                    bookManager.CurrentUser = null;
                                    Console.Clear();
                                    break;
                                default:
                                    Console.WriteLine("Incorrect input. Repeat please;");
                                    break;
                            }
                        }
                        bookManager.SaveNotebook();
                }
            }
        }
        
    }
}
