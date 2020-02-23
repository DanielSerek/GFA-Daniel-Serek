using System;
using System.Collections.Generic;
using System.Text;

namespace GreenFoxInheritance
{
    class Student : Person
    {
        private string previousOrganization;
        private int skippedDays;

        // TODO Zkontrolovat, jestli funguje defaultní přiřazení 0 dnů k skippeddays
        public Student(string name, int age, string gender, string previousOrganization, int skippedDays = 0) : base(name, age, gender)
        {
            this.previousOrganization = previousOrganization;
            this.skippedDays = skippedDays;
        }

        public Student()
        {
            name = "Jane Doe";
            age = 30;
            gender = "female";
            previousOrganization = "The School of Life";
            skippedDays = 0;
        }


        public override void GetGoal()
        {
            Console.WriteLine("My goal is: Be a junior software developer.");
        }

        public override void Introduce()
        {
            Console.WriteLine($"Hi, I'm {this.name}, a {this.age} year old {this.gender} from {this.previousOrganization} who skipped {this.skippedDays} days form the course already.");
        }

        public void SkipDays(int numberOfDays)
        {
            skippedDays += numberOfDays;
        }

    }
}
