using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalsZOO
{
    public abstract class Animal
    {
        protected string Name;
        protected string Gender;
        protected int Age;

        public string GetName()
        {
            return $"{Name}, want a child from";
        }

        public abstract string WantChild();
    }
}
