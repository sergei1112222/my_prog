﻿using System;
using System.Collections.Generic;
using Structure;
using System.IO;
using System.Numerics;


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
                    gettingList.PushHead(_element);
                }
            }
            return gettingList;
        }
        
        public void AddPerson(Person person)
        {

            _bookPerson.PushHead(person);
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
                        DateTime Birthday = Convert.ToDateTime(reader.ReadString());
                        char Gender = reader.ReadChar();
                        string Phonenumber = reader.ReadString();
                        Person _person = new Person(Name, Surname, Birthday, Gender, Phonenumber);
                        this.AddPerson(_person);
                    }
                }
            }
            catch
            {
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
                        writer.Write(elem.Birthday.Date.ToString());
                        writer.Write(elem.Gender);
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
        public DateTime Birthday { set; get; }
        public char Gender { set; get; }
        public int Age { get; }
        public string Phonenumber { set; get; }

        private int GetAge()
        {
            var now = DateTime.Today;
            return now.Year - this.Birthday.Year - 1 +
                ((now.Month > this.Birthday.Month || now.Month == this.Birthday.Month && now.Day >= this.Birthday.Day) ? 1 : 0);
        }
        public Person(string name, string surname, DateTime birthday,char gender,  string phonenumber)
        {
            Name = name;
            Surname = surname;
            Birthday = birthday;
            Gender = gender;
            Age = GetAge();
            Phonenumber = phonenumber;
        }
    }
}
