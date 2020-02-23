using System;
using System.Collections.Generic;
using System.Text;

namespace GreenFoxInheritance
{
    class Cohort
    {
        private string Name;
        private List<Student> Students;
        private List<Mentor> Mentors;

        public Cohort(string name)
        {
            this.Name = name;
            this.Students = new List<Student>();
            this.Mentors = new List<Mentor>();
        }

        public void AddStudent (Student student)
        {
            Students.Add(student);
        }

        public void AddMentor(Mentor mentor)
        {
            Mentors.Add(mentor);
        }

        public void Info()
        {
            Console.WriteLine($"The {this.Name} cohort has {this.Students.Count} students and {this.Mentors.Count} mentors.");
        }
    }
}
