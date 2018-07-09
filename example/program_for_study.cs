using System;
using System.Collections;

class Person
{
    public string Name;
    public string Surname;
    public int age;
    public Person(string name, string surname, int age)
    {
        this.Name = name;
        this.Surname = surname;
        this.age = age;
    }
    public string get_info()
    {
        return this.Name + ", " + this.Surname + ", " + this.age.ToString();
    }

}
/*class JobPerson : Person
{
    public string job;
}*/