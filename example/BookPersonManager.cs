using System;
using System.Collections.Generic;
using Structure;
using System.IO;
using System.Numerics;


namespace BookPerson
{
    public class Person
    {
        

        public uint ID { get; private set; }
        public string Name { set; get; }
        public string Surname { set; get; }
        public DateTime Birthday { set; get; }
        public char Gender { set; get; }
        public int Age { get { return GetAge(); } }
        public string Phonenumber { set; get; }

        public Person(uint id, string name, string surname, DateTime birthday, char gender, string phonenumber)
        {
            ID = id;
            Name = name;
            Surname = surname;
            Birthday = birthday;
            Gender = gender;
            //Age = GetAge();
            Phonenumber = phonenumber;
        } 

        private int GetAge()
        {
            DateTime nowDate = DateTime.Today;
            int age = nowDate.Year - Birthday.Year;
            if (Birthday > nowDate.AddYears(-age))
                age--;
            return age;

            //return now.Year - this.Birthday.Year - 1 +
            //  ((now.Month > this.Birthday.Month || now.Month == this.Birthday.Month && now.Day >= this.Birthday.Day) ? 1 : 0);
        }


    }
    public class BookPersonManager
    {
        private uint _intToDelete = 0;
        private uint _lastID;
        private const string PATH = "DB.dat";
        private Bidirectionallist<Person> _bookPerson = new Bidirectionallist<Person>();

        public int PersonCount
        {
            get { return _bookPerson.Count; }
        }

        public BookPersonManager() { }

        public void AddPerson(Person person)
        {
            _bookPerson.PushTail(person);
        }

        public void AddPerson(string name, string surname, DateTime birthday, char gender, string phonenumber)
        {
            Person person = new Person(++_lastID, name, surname, birthday, gender, phonenumber);
            _bookPerson.PushTail(person);
        }

        private bool localPredicate(Person pers)
        {
            return (pers.ID == this._intToDelete);
        }

        public bool RemovePerson(uint ID)
        {
            _intToDelete = ID;

            return _bookPerson.RemoveRequest(localPredicate, false);
        } 

        /*public bool RemoveRequest(string request, int comparator)
        {
            

        }*/

        public int Count {
            get { return this._bookPerson.Count; }
        }

        public Bidirectionallist<Person> GetPersonList()
        {
            Bidirectionallist<Person> gettingList = new Bidirectionallist<Person>(_bookPerson);
            return gettingList;
        }

        public Bidirectionallist<Person> SelectRequest(string request)
        {
            return SelectList(request);
        }

        
        public void SaveNotebook()
        {
            try
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(PATH, FileMode.Create)))
                {
                    foreach (var elem in this._bookPerson)
                    {
                        writer.Write(elem.ID);
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

        public bool ReadNotebook()
        {
            try
            {
                using (BinaryReader reader = new BinaryReader(File.Open(PATH, FileMode.OpenOrCreate)))
                {
                    while (reader.PeekChar() > -1)
                    {
                        uint id = reader.ReadUInt32();
                        string Name = reader.ReadString();
                        string Surname = reader.ReadString();
                        DateTime Birthday = Convert.ToDateTime(reader.ReadString());
                        char Gender = reader.ReadChar();
                        string Phonenumber = reader.ReadString();
                        Person _person = new Person(id, Name, Surname, Birthday, Gender, Phonenumber);
                        this.AddPerson(_person);
                    }
                }
                if (this.PersonCount > 0)
                    _lastID = this._bookPerson.FindElementInd(_bookPerson.Count - 1).ID;
                else
                    _lastID = 0;
            }
            catch
            {
                return false;
            }
            return true;
        }


        private Bidirectionallist<Person> SelectList(string request)
        {
            Bidirectionallist<Person> gettingList = new Bidirectionallist<Person>();
            foreach (var _element in this._bookPerson)
            {
                if ((_element.Name + _element.Surname).IndexOf(request) != -1)
                {
                    gettingList.PushHead(_element);
                }
            }
            return gettingList;
        }
    }

    class Authorization
    {

    }
    
}
