using System;
using System.Collections.Generic;

namespace GreenFoxInheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            // Exercise with the use of interface
            
            
            //var x = new Person();
            //x.Introduce();
            //x.GetGoal();

            //var y = new Student();
            //y.Introduce();
            //y.GetGoal();

            //var z = new Mentor();
            //z.Introduce();
            //z.GetGoal();

            //var j = new Sponsor();
            //j.Introduce();
            //j.GetGoal();

            var people = new List<Person>();

            var mark = new Person("Mark", 46, "male");
            people.Add(mark);
            var jane = new Person();
            people.Add(jane);
            var john = new Student("John Doe", 20, "male", "BME");
            people.Add(john);
            var student = new Student();
            people.Add(student);
            var gandhi = new Mentor("Gandhi", 148, "male", "senior");
            people.Add(gandhi);
            var mentor = new Mentor();
            people.Add(mentor);
            var sponsor = new Sponsor();
            people.Add(sponsor);
            var elon = new Sponsor("Elon Musk", 46, "male", "SpaceX");
            people.Add(elon);

            student.SkipDays(3);

            for (int i = 0; i < 5; i++)
            {
                elon.Hire();
            }

            for (int i = 0; i < 3; i++)
            {
                sponsor.Hire();
            }

            foreach (var person in people)
            {
                person.Introduce();
                person.GetGoal();
            }

            Cohort awesome = new Cohort("AWESOME");
            awesome.AddStudent(student);
            awesome.AddStudent(john);
            awesome.AddMentor(mentor);
            awesome.AddMentor(gandhi);
            awesome.Info();

            Console.WriteLine("\nCloning");
            Student Daniel = new Student("Daniel Serek", 39, "male", "innogy");
            Student DanielClone = Daniel.Clone() as Student;
            DanielClone.Introduce();
            DanielClone.Name = "Clone of Daniel Serek";
            DanielClone.Introduce();
        }
    }
}
