using System;
using System.Collections.Generic;
using System.Text;

namespace GreenFoxInheritance
{
    public class Person
    {
        public string Name;
        public int Age;
        public string Gender;

        public Person(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public Person()
        {
            Name = "Jane Doe";
            Age = 30;
            Gender = "female";
        }

        public virtual void Introduce()
        {
            Console.WriteLine($"Hi, I'm {this.Name}, a {this.Age} year old {this.Gender}");
        }

        public virtual void GetGoal()
        {
            Console.WriteLine("My goal is: Live for the moment!");
        }
    }
}
