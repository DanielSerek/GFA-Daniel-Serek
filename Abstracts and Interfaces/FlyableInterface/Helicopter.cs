using System;
using System.Collections.Generic;
using System.Text;

namespace FlyableInterface
{
    class Helicopter : Vehicle, IFlyable
    {
        public void Fly()
        {
            Console.WriteLine("Helicopter is flying.");
        }

        public void Land()
        {
            Console.WriteLine("Helicopter is landing.");
        }

        public void TakeOff()
        {
            Console.WriteLine("Helicopter is taking off.");
        }
    }
}
