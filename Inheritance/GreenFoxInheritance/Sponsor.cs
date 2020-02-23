using System;
using System.Collections.Generic;
using System.Text;

namespace GreenFoxInheritance
{
    class Sponsor : Person
    {
        private string company;
        private int hiredStudents;

        // TODO Check whether the default number of hired students work
        public Sponsor(string name, int age, string gender, string company, int hiredStudents = 0) : base(name, age, gender)
        {
            this.company = company;
            this.hiredStudents = hiredStudents;
        }

        public Sponsor()
        {
            name = "Jane Doe";
            age = 30;
            gender = "female";
            company = "Google";
            hiredStudents = 0;
        }

        public override void Introduce()
        {
            Console.WriteLine($"Hi, I'm {this.name}, a {this.age} year old {this.gender} who represents {this.company} and hired {this.hiredStudents} students so far.");
        }

        public void Hire()
        {
            hiredStudents++;
        }

        public override void GetGoal()
        {
            Console.WriteLine("My goal is: Hire brilliant junior software developers.");
        }

    }
}
