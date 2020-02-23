using System;

namespace FlyableInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            Helicopter heli = new Helicopter();
            heli.TakeOff();
            heli.Fly();
            heli.Land();
        }
    }
}
