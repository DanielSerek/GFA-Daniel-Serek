using System;

namespace JurasicParkApp
{
    class Program
    {
        static void Main(string[] args)
        {
            JurasicPark jurasicPark = new JurasicPark();

            Dinosaur dino1 = new Carnivor(Dinosaur.Name.Stegosaurus, 20, 1000);
            Dinosaur dino2 = new Herbivore(Dinosaur.Name.Triceratops, 50);
            Dinosaur dino3 = new Water(Dinosaur.Name.Velociraptor, 50);
            Dinosaur dino4 = new Carnivor(Dinosaur.Name.Archaeopteryx, 50);
            Dinosaur dino5 = new Carnivor(Dinosaur.Name.Stegosaurus, 50, 5);


            jurasicPark.Add(dino1);
            jurasicPark.Add(dino2);
            jurasicPark.Add(dino3);
            jurasicPark.Add(dino4);
            jurasicPark.Add(dino5);

            dino1.Roar();
            dino2.Roar();
            dino3.Roar();

            dino1.Pet();
            dino2.Pet();
            dino3.Pet();

            Console.WriteLine();
            jurasicPark.GetSpecies();

            Console.WriteLine();
            jurasicPark.Visit();

            Console.WriteLine();
            jurasicPark.Statistics();

            jurasicPark.Adopt(dino1);
            jurasicPark.Adopt(dino1);

            Console.WriteLine();
            jurasicPark.GetDinosaurByType("Water");

            Console.WriteLine();
            Console.WriteLine(jurasicPark.GetDinosaurByName(Dinosaur.Name.Stegosaurus));

            jurasicPark.Deport(dino1);
        }
    }
}
