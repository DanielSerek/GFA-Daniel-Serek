using System;
using System.Collections.Generic;
using System.Text;

namespace GreenFoxInheritance
{
    class Sponsor : Person
    {
        private string Company;
        private int HiredStudents;

        // TODO Check whether the default number of hired students work
        public Sponsor(string name, int age, string gender, string company, int hiredStudents = 0) : base(name, age, gender)
        {
            this.Company = company;
            this.HiredStudents = hiredStudents;
        }

        public Sponsor()
        {
            Name = "Jane Doe";
            Age = 30;
            Gender = "female";
            Company = "Google";
            HiredStudents = 0;
        }

        public override void Introduce()
        {
            Console.WriteLine($"Hi, I'm {this.Name}, a {this.Age} year old {this.Gender} who represents {this.Company} and hired {this.HiredStudents} students so far.");
        }

        public void Hire()
        {
            HiredStudents++;
        }

        public override void GetGoal()
        {
            Console.WriteLine("My goal is: Hire brilliant junior software developers.");
        }

    }
}
