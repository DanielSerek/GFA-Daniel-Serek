using System;
using System.Collections.Generic;
using System.Text;

namespace Teachers_and_Students
{
    class Student
    {
        public int ID;
        public string FirstName;
        public string Surname;
        public List<string> Subjects;
        public List<Teacher> Teachers;

        public Student(int id, string firstName, string surname, List<string> subjects, List<Teacher> teachers)
        {
            ID = id;
            FirstName = firstName;
            Surname = surname;
            Subjects = subjects;
            Teachers = teachers;
        }

        public void Learn()
        {
            Console.WriteLine($"{FirstName} {Surname} is learning new stuff.");
        }

        public void Question(Teacher teacher)
        {
            Console.Write($"Student {FirstName} {Surname} is curiuous... ");
            teacher.Answer();
            
        }

    }
}
