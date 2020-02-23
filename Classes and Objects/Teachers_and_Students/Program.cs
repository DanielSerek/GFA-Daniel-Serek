using System;
using System.Collections.Generic;


namespace Teachers_and_Students
{
    class Program
    {
        static void Main(string[] args)
        {
            Teacher Misi = new Teacher("Mihai", "Neumann");
            Teacher Ceasar = new Teacher("Gaius", "Julius");

            List<string> subjects = new List<string> { "object-oriented programming", "piano lessons" };
            List<Teacher> teachers = new List<Teacher> { Misi, Ceasar };
            Student student1 = new Student(1, "Albert", "Einstein", subjects, teachers);


            Console.WriteLine(student1.Subjects[0]);
            Console.WriteLine(Misi.FirstName + " " + Misi.Surname);

            student1.Learn();

            Misi.Answer();
            Ceasar.Answer();

            Misi.Teach(student1);

            student1.Question(Misi);

        }
    }
}
