using System;
using System.Collections.Generic;
using System.Text;

namespace GreenFoxInheritance
{
    public class Student : Person, ICloneable
    {
        private string PreviousOrganization;
        private int SkippedDays;

        // TODO Zkontrolovat, jestli funguje defaultní přiřazení 0 dnů k skippeddays
        public Student(string name, int age, string gender, string previousOrganization, int skippedDays = 0) : base(name, age, gender)
        {
            PreviousOrganization = previousOrganization;
            SkippedDays = skippedDays;
        }

        public Student()
        {
            Name = "Jane Doe";
            Age = 30;
            Gender = "female";
            PreviousOrganization = "The School of Life";
            SkippedDays = 0;
        }


        public override void GetGoal()
        {
            Console.WriteLine("My goal is: Be a junior software developer.");
        }

        public override void Introduce()
        {
            Console.WriteLine($"Hi, I'm {this.Name}, a {this.Age} year old {this.Gender} from {this.PreviousOrganization} who skipped {this.SkippedDays} days form the course already.");
        }

        public void SkipDays(int numberOfDays)
        {
            SkippedDays += numberOfDays;
        }

        // Implementation of Clone method using ICloneable interface - the method clones an object
        public object Clone()
        {
            return new Student(this.Name, this.Age, this.Gender, this.PreviousOrganization, this.SkippedDays);
        }
    }
}
