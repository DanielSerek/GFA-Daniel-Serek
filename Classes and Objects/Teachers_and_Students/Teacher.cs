using System;
using System.Collections.Generic;
using System.Text;

namespace Teachers_and_Students
{
    class Teacher
    {
        public string FirstName;
        public string Surname;


        public Teacher(string firstname, string surname)
        {
            FirstName = firstname;
            Surname = surname;
        }

        public void Answer()
        {
            Console.WriteLine($"Teacher {FirstName} {Surname} answers a question.");
        }

        public void Teach(Student student)
        {
            Console.Write($"Teacher {FirstName} {Surname} teaches... ");
            student.Learn();
        }
    }
}
