using System;
using System.Collections.Generic;
using System.Text;

namespace GreenFoxInheritance
{
    class Person
    {
        protected string name;
        protected int age;
        protected string gender;

        public Person(string name, int age, string gender)
        {
            this.name = name;
            this.age = age;
            this.gender = gender;
        }

        public Person()
        {
            name = "Jane Doe";
            age = 30;
            gender = "female";
        }

        public virtual void Introduce()
        {
            Console.WriteLine($"Hi, I'm {this.name}, a {this.age} year old {this.gender}");
        }

        public virtual void GetGoal()
        {
            Console.WriteLine("My goal is: Live for the moment!");
        }
    }
}
