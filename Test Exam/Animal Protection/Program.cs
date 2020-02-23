using System;
using System.Text;

namespace Animal_Protection
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Cat cat1 = new Cat("Fiona", "Kristina", true);
            Dog dog1 = new Dog("Frodo", "Mirek", true);
            Parrot parrot1 = new Parrot("Freddy", "Jana", false);
            Animal_shelter shelter1 = new Animal_shelter();   // I can't call methods from this class without instantiating it

            
            int num;
            num = shelter1.Rescue(cat1);
            num = shelter1.Rescue(dog1);
            num = shelter1.Rescue(parrot1);
            Console.WriteLine(num);

            Console.WriteLine(parrot1.ToString()); 
            parrot1.Heal();
            Console.WriteLine(parrot1.ToString());
            Console.WriteLine(parrot1.IsAdoptable());



            shelter1.AddAdopter("Peter Pan");
            shelter1.EarnDonation(50);
            Console.WriteLine(shelter1.ToString());

            shelter1.FindNewOwner();
            Console.WriteLine(shelter1.ToString());



        }
    }

    
}
