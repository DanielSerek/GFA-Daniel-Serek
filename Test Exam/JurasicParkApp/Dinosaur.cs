using System;
using System.Collections.Generic;
using System.Text;

namespace JurasicParkApp
{
    public abstract class Dinosaur
    {
        public enum Name{
            Tyrannosaurus,
            Triceratops,
            Velociraptor,
            Stegosaurus,
            Spinosaurus,
            Archaeopteryx
        }
        
        public int Water;
        public int Weight;
        public Name DinoName;
        public bool Adopted;

        public Dinosaur(Name name, int water)
        {
            DinoName = name;
            Water = water;
            Random random = new Random();
            Weight = random.Next(1000, 2500);
        }
        public Dinosaur(Name name, int water, int weight)
        {
            DinoName = name;
            Water = water;
            Weight = weight;
        }

        public abstract void Roar();

        public abstract void Pet();
    }
}
