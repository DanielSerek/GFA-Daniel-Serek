using System;
using System.Collections.Generic;
using System.Linq;

namespace Matchmaking
{
    class Program
    {
        static void Main(string[] args)
        {
            var girls = new List<string> { "Eve", "Ashley", "Claire", "Kat", "Jane", "Kristina", "Petra", "Tea" };
            var boys = new List<string> { "Joe", "Fred", "Tom", "Todd", "Neef", "Jeff" };
            var couples = new List<string>(girls.Count + boys.Count);
            couples = MakingMatches(girls, boys);
            foreach (var couple in couples)
            {
                Console.Write(couple + " ");
            }
        }
        static List<string> MakingMatches(List<string> girls, List<string> boys)
        {
            List<string> couples = new List<string>(girls.Count + boys.Count);

            int i = 0;
            do
            {
                couples.Add(girls[i]);
                couples.Add(boys[i]);
                i++;
            } while (i < girls.Count && i < boys.Count);

            if (girls.Count > boys.Count)
            {
                for (int j = boys.Count; j < girls.Count; j++)
                {
                    couples.Add(girls[j]);
                }
            }
            else
            {
                for (int k = girls.Count; k < boys.Count; k++)
                {
                    couples.Add(boys[k]);
                }
            }


            /*
            // There is the same number of boys and girls
            if (girls.Count == boys.Count)
            {
                for (int i = 0; i < boys.Count; i++)
                {
                    couples.Add(girls[i]);
                    couples.Add(boys[i]);
                }
            }

            // There are more girls than boys
            if (girls.Count > boys.Count)
            {
                for (int i = 0; i < boys.Count; i++)
                {
                    couples.Add(girls[i]);
                    couples.Add(boys[i]);
                }
                for (int i = boys.Count; i < girls.Count; i++)
                {
                    couples.Add(girls[i]);
                }
            }

            // There are more boys than girls
            if (boys.Count > girls.Count)
            {
                for (int i = 0; i < girls.Count; i++)
                {
                    couples.Add(girls[i]);
                    couples.Add(boys[i]);
                }
                for (int i = girls.Count; i < boys.Count; i++)
                {
                    couples.Add(boys[i]);
                }
            */
            return couples;
        }
            
           
    }
        
    
}
