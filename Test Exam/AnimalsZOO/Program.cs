using System;

namespace AnimalsZOO
{
    class Program
    {
        static void Main(string[] args)
        {
            ZOO zoo = new ZOO(100, 100);
            Animal LionKing = new Lion("Lion King");
            Animal WereWolf = new Wolf("Werewolf");
            Animal BigOne = new Elephant("Big One");

            zoo.AddAnimal(LionKing);
            zoo.AddAnimal(WereWolf);
            zoo.AddAnimal(BigOne);
            
            Console.WriteLine(LionKing.GetStatus());
            Console.WriteLine(WereWolf.GetStatus());
            Console.WriteLine(BigOne.GetStatus());

            Console.WriteLine(LionKing.IsHerbivore());
            Console.WriteLine(WereWolf.IsHerbivore());
            Console.WriteLine(BigOne.IsHerbivore());

            LionKing.Eat(10);
            WereWolf.Eat(5);
            BigOne.Eat(40);

            zoo.SpendNormalDay();
            Console.WriteLine(LionKing.GetStatus());
            Console.WriteLine(WereWolf.GetStatus());
            Console.WriteLine(BigOne.GetStatus());

            zoo.SpendQuarantineDay();
            Console.WriteLine(LionKing.GetStatus());
            Console.WriteLine(WereWolf.GetStatus());
            Console.WriteLine(BigOne.GetStatus());

            zoo.SpendNormalDay();
            Console.WriteLine();
            Console.WriteLine(LionKing.GetStatus());
            Console.WriteLine(WereWolf.GetStatus());
            Console.WriteLine(BigOne.GetStatus());
            Console.WriteLine(zoo.GetFullestStatus(true));

        }
    }
}
