using System;
using System.Collections.Generic;
using System.Text;

namespace Sharpie
{
    public class Sharpie
    {
        public string Color;
        public float Width;
        public float InkAmount;

        public Sharpie(string color, float width, float inkAmount)
        {
            Console.Write("Give me color: ");
            Color = Console.ReadLine();
            Console.Write("Give me width: ");
            Width = float.Parse(Console.ReadLine());
            InkAmount = inkAmount = 100;
        }
        public Sharpie()   // Constructor for creating object without predefined parameters
            :this("", 0, 0)
        { }

        public void SayHi()
        {
            Console.WriteLine($"Color: {Color} Width: {Width} InkAmount: {InkAmount}");
        }
    }
}
