using System;
using System.Collections.Generic;
using System.Text;

namespace Human
{
    class Human
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Iq { get; set; }

        public Human(string name, int age, int iq)
        {
            Name = name;
            Age = age;
            Iq = iq;
        }

        public bool IsSmart()
        {
            return Iq > 100;
        }

        public bool IsNameLess()
        {
            return Name == "unkown" || Name == "";
        }

        public void BeSmarter()
        {
            Iq += 20;
        }
    }
}
