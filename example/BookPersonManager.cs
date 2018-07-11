using System;
using System.Collections.Generic;
using Structure;


namespace BookPerson
{
    class BookPersonManager
    {        
        private Bidirectionallist<Person> BookPerson = new Bidirectionallist<Person>();
        public void AddPerson(string name, string surname, char gender, int age, string phonenumber)
        {
            BookPerson.PushHead(new Person(name, surname, gender, age, phonenumber));
        }
       
        public Bidirectionallist<Person> GetPersonList()
        {
            Bidirectionallist<Person> gettingList = new Bidirectionallist<Person>(BookPerson);
            return gettingList;
        }
        public BookPersonManager() { }
    }
    public class Person
    {
        public string Name { set; get; }
        public string Surname { set; get; }
        public char Gender { set; get; }
        public int Age { set; get; }
        public string Phonenumber { set; get; }
        public Person(string name, string surname, char gender, int age, string phonenumber)
        {
            Name = name;
            Surname = surname;
            Gender = gender;
            Age = age;
            Phonenumber = phonenumber;
        }
    }
}
