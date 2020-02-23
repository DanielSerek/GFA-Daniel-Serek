using System;

namespace Aircraft_Carrier
{
    class Program
    {
        static void Main(string[] args)
        {

            // Create two separate carriers
            Carrier carrier1 = new Carrier("George Washington", 2000, 2000);
            Carrier carrier2 = new Carrier("Ronald Reagan", 7000, 3000);

            // Create aircrafts
            F16 aircraft1 = new F16();
            F16 aircraft2 = new F16();
            F35 aircraft3 = new F35();
            F35 aircraft4 = new F35();
                       
            // Add aircrafts to the carriers
            carrier1.Add(aircraft1);
            carrier1.Add(aircraft2);
            carrier2.Add(aircraft3);
            carrier2.Add(aircraft4);

            // Testing 
            Console.WriteLine(aircraft1.GetStatus());
            carrier1.Fill();
            Console.WriteLine(aircraft1.GetStatus());
            
            carrier2.Fill();
            carrier2.Fill();

            Console.WriteLine(carrier1.FightBetweenCarriers(carrier2));
            carrier1.Fill();
            carrier2.Fill();
            Console.WriteLine(carrier1.FightBetweenCarriers(carrier2));


        }
    }
}
