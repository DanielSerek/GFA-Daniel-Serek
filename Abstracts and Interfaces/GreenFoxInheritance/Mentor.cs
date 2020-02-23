using System;
using System.Collections.Generic;
using System.Text;

namespace GreenFoxInheritance
{
    class Mentor : Person
    {
        private string Level;

        public Mentor(string name, int age, string gender, string level) : base(name, age, gender)
        {
            base.Name = name;
            base.Age = age;
            base.Gender = gender;
            this.Level = level;
        }
        
        public Mentor()
        {
            base.Name = "Jane Doe";
            base.Age = 30;
            base.Gender = "female";
            this.Level = "intermediate";
        }

        public override void GetGoal()
        {
            Console.WriteLine("My goal is: Educate brilliant junior software developers");
        }

        public override void Introduce()
        {
            Console.WriteLine($"Hi, I'm {Name}, a {Age} year old {Gender} {Level} mentor.");
        }
    }
}
