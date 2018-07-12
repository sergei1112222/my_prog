using System;
using System.Collections.Generic;
using Structure;
using System.IO;


namespace BookPerson
{
    class BookPersonManager
    {        
        private string PATH = "DB.dat";
        private Bidirectionallist<Person> _bookPerson = new Bidirectionallist<Person>();

        private Bidirectionallist<Person> SelectList(string request)
        {
            Bidirectionallist<Person> gettingList = new Bidirectionallist<Person>();
            foreach (var _element in this._bookPerson)
            {
                if ((" "+_element.Name + _element.Surname).IndexOf(request) != -1)
                {
                    //gettingList.PushHead(new Person(_element.Name, _element.Surname, _element.Gender, _element.Age, _element.Phonenumber));
                    gettingList.PushHead(_element);
                }
            }
            return gettingList;
        }
        
        public void AddPerson(string name, string surname, string birthday,char gender, int age, string phonenumber)
        {
            _bookPerson.PushHead(new Person(name, surname, birthday, gender, age, phonenumber));
        }
        public Bidirectionallist<Person> GetPersonList()
        {
            Bidirectionallist<Person> gettingList = new Bidirectionallist<Person>(_bookPerson);
            return gettingList;
        }
        public Bidirectionallist<Person> SelectRequest(string request)
        {
            //Bidirectionallist<Person> gettingList = new Bidirectionallist<Person>(BookPerson);
            return SelectList(request);
        }

        public BookPersonManager() {
            try
            {
                using (BinaryReader reader = new BinaryReader(File.Open(PATH, FileMode.OpenOrCreate)))
                {
                    while (reader.PeekChar() > -1)
                    {
                        string Name = reader.ReadString();
                        string Surname = reader.ReadString();
                        string Birthday = reader.ReadString();
                        char Gender = reader.ReadChar();
                        int Age = reader.ReadInt32();
                        string Phonenumber = reader.ReadString();
                        this.AddPerson(Name, Surname, Birthday, Gender, Age, Phonenumber);
                       // Console.WriteLine("Reading success");
                    }
                }
            }
            catch
            {
               // Console.WriteLine("Reading unsuccess");
            }
        }
        public void SaveNotebook()
        {
            try
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(PATH, FileMode.OpenOrCreate)))
                {
                    foreach (var elem in this._bookPerson)
                    {
                        writer.Write(elem.Name);
                        writer.Write(elem.Surname);
                        writer.Write(elem.Birthday);
                        writer.Write(elem.Gender);
                        writer.Write(elem.Age);
                        writer.Write(elem.Phonenumber);
                    }
                }
            }
            catch
            {
                
            }
        }
    }
    public class Person
    {
        public string Name { set; get; }
        public string Surname { set; get; }
        public string Birthday { set; get; }
        public char Gender { set; get; }
        public int Age { set; get; }
        public string Phonenumber { set; get; }
        public Person(string name, string surname, string birthday,char gender, int age, string phonenumber)
        {
            Name = name;
            Surname = surname;
            Birthday = birthday;
            Gender = gender;
            Age = age;
            Phonenumber = phonenumber;
        }
    }
}
