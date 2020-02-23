using System;
using System.Collections.Generic;
using System.Text;

namespace GreenFoxInheritance
{
    class Mentor : Person
    {
        private string level;

        public Mentor(string name, int age, string gender, string level) : base(name, age, gender)
        {
            base.name = name;
            base.age = age;
            base.gender = gender;
            this.level = level;
        }
        
        public Mentor()
        {
            base.name = "Jane Doe";
            base.age = 30;
            base.gender = "female";
            this.level = "intermediate";
        }

        public override void GetGoal()
        {
            Console.WriteLine("My goal is: Educate brilliant junior software developers");
        }

        public override void Introduce()
        {
            Console.WriteLine($"Hi, I'm {name}, a {age} year old {gender} {level} mentor.");
        }
    }
}
