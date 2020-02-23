using System;
using System.Collections.Generic;
using System.Text;

namespace GreenFoxInheritance
{
    class Cohort
    {
        private string name;
        private List<Student> students;
        private List<Mentor> mentors;

        public Cohort(string name)
        {
            this.name = name;
            this.students = new List<Student>();
            this.mentors = new List<Mentor>();
        }

        public void AddStudent (Student student)
        {
            students.Add(student);
        }

        public void AddMentor(Mentor mentor)
        {
            mentors.Add(mentor);
        }

        public void Info()
        {
            Console.WriteLine($"The {this.name} cohort has {this.students.Count} students and {this.mentors.Count} mentors.");
        }
    }
}
