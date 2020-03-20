using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JurasicParkApp
{
    
    public class JurasicPark
    {
        private List<Dinosaur> dinosaurs;
        private static int adoptedDinos = 0;


        public JurasicPark()
        {
            dinosaurs = new List<Dinosaur>();
        }

        public void Add(Dinosaur dino)
        {
            dinosaurs.Add(dino);
        }
        
        public void GetSpecies()
        {
            Console.WriteLine("The park has these lovely creatures:");
            List<string> species = new List<string>();
            
            foreach (var item in dinosaurs)
            {
                if (!species.Contains(item.DinoName.ToString())) species.Add(item.DinoName.ToString());
            }

            foreach (var specie in species)
            {
                Console.WriteLine(specie);
            }
        }

        public void Visit()
        {
            TimeSpan start = new TimeSpan(10, 0, 0); //10 o'clock
            TimeSpan end = new TimeSpan(20, 0, 0); //20 o'clock
            TimeSpan now = DateTime.Now.TimeOfDay;

            // Park is open
            if ((now > start) && (now < end))
            {
                foreach (var dino in dinosaurs)
                {
                    Console.WriteLine(dino.DinoName.ToString());
                }
            }
            else Console.WriteLine("The park is closed now"); //Park is closed
        }

        public void Statistics()
        {
            var sortedDinos = dinosaurs.OrderBy(x => x.DinoName.ToString()).ThenBy(y => y.Weight);

            foreach (var dino in sortedDinos)
            {
                Console.WriteLine($"{dino.DinoName}, weight: {dino.Weight}");
            }
        }

        public void Adopt(Dinosaur dino)
        {
            if (adoptedDinos == 0)
            {
                dino.Adopted = true;
                Console.WriteLine($"You have adopted {dino.DinoName}, {dino.Weight}");
                adoptedDinos++;
            }
            else Console.WriteLine("You have already adopted a dinosaur. How many of them do you want to adopt?!");
        }

        public void GetDinosaurByType(string type)
        {
            for (int i = 0; i < dinosaurs.Count; i++)
            {
                switch (type)
                {
                    case "Carnivor":
                        if (dinosaurs[i] is Carnivor) Console.WriteLine(dinosaurs[i].DinoName);
                        break;
                    case "Herbivore":
                        if (dinosaurs[i] is Herbivore) Console.WriteLine(dinosaurs[i].DinoName);
                        break;
                    case "Water":
                        if (dinosaurs[i] is Water) Console.WriteLine(dinosaurs[i].DinoName);
                        break;
                }
            }
        }

        public string GetDinosaurByName(Enum name)
        {
            string dinos = "";
            foreach (var dinosaur in dinosaurs)
            {
                if (dinosaur.DinoName.Equals(name))
                {
                    dinos += dinosaur.DinoName + " " + dinosaur.Weight + Environment.NewLine;
                }
            }
            if (string.IsNullOrEmpty(dinos)) dinos = null;
            return dinos;
        }

        public void Deport (Dinosaur dino)
        {
            Console.WriteLine($"Get out, you {dino.DinoName} son of a bitch!");
            dinosaurs.Remove(dino);
        }
    }
}
