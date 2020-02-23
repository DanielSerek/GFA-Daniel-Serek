using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            // STRING //

            string str = "something";
            string str2 = "the joy of joining the joystick club";
            string str3 = "This IS a NeW őűŰÓÉüöí ž";
            string str4 = " This has new line\n";

            Console.WriteLine("str: " + str);
            Console.WriteLine("str.Length: " + str.Length);
            Console.WriteLine("str.Substring(2, 4): " + str.Substring(2, 4));
            Console.WriteLine("str.Substring(2): " + str.Substring(2));

            char c = '_';
            string s = c.ToString();
            Console.WriteLine("str2: " + str2);
            Console.WriteLine("str2.Replace(' ', '_'): " + str2.Replace(" ", s));
            Console.WriteLine("str2.Replace(\"jo\", \"so\"): " + str2.Replace("jo", "so"));
            Console.WriteLine("str2.Replace(\"joy\", \"sadness\"): " + str2.Replace("joy", "sadness"));

            Console.WriteLine("str.Equals(\"something\"): " + str.Equals("something"));
            Console.WriteLine("str.Equals(\"fox\"): " + str.Equals("fox"));
            Console.WriteLine("str == something: " + (str == "something"));

            Console.WriteLine("str3: " + str3);
            Console.WriteLine("str3.ToLower: " + str3.ToLower());
            Console.WriteLine("str3.ToUpper: " + str3.ToUpper());

            Console.WriteLine("str.Contains('s'): " + str.Contains('s'));
            Console.WriteLine("str.Contains('r'): " + str.Contains('r'));
            Console.WriteLine("str.Contains(\"so\"): " + str.Contains("so"));
            Console.WriteLine("str.Contains(\"ro\"): " + str.Contains("ro"));

            Console.WriteLine("str.IndexOf('t'): " + str.IndexOf('t'));
            Console.WriteLine("str.IndexOf(\"th\"): " + str.IndexOf("th"));

            int ind = str2.IndexOf('j');
            Console.WriteLine("str2.IndexOf('j'): " + ind);
            Console.WriteLine("str2.IndexOf('j', " + ind + "): " + str2.IndexOf('j', ind + 1));

            Console.WriteLine("str2.LastIndexOf('j'): " + str2.LastIndexOf('j'));
            Console.WriteLine("str2.LastIndexOf('j', 22): " + str2.LastIndexOf('j', 22));

            outputList("str2.Split(' ')", new List<string>((str2.Split(' '))));
            outputList("str2.Split('j')", new List<string>((str2.Split('j'))));
            outputList("str2.Split(\"joy\")", new List<string>((str2.Split("joy"))));

            Console.WriteLine("str2.Split(\"joy\")[1].Trim(): \"" + str2.Split("joy")[1].Trim() + "\"");

            Console.WriteLine("str4: \"" + str4 + "\"");
            Console.WriteLine("str4.Trim(): \"" + str4.Trim() + "\"");

            // STRING BUILDER //
            Console.WriteLine();

            Console.WriteLine(str[0]);
            int x = 5;
            x = 6;
            x++;

            string ex = "dog";
            ex += " godasieuufgawoieufhqwoieufhqioewaufhqwopieufhqwoeiufgweoiauufgweiufh";

            StringBuilder build = new StringBuilder(50);
            for (int i = 0; i < 40; i++)
            {
                build.Append('t');
            }
            for (int i = 0; i < 40; i++)
            {
                build.Append('b');
            }

            // LIST //
            Console.WriteLine();

            int[] arr = new int[10];

            List<int> myFirstList = new List<int>(5);

            myFirstList.Add(3);
            myFirstList.Add(38);
            myFirstList.Add(2);
            myFirstList.Add(63);

            outputList("myFirstList", myFirstList);

            List<int> list2 = new List<int> { 2, 4, 767, 12, 2, 0 };
            outputList("list2", list2);

            list2.Remove(2);
            outputList("list2.Remove(2), list2", list2);

            list2.RemoveAt(2);
            outputList("list2.RemoveAt(2), list2", list2);


            myFirstList.AddRange(list2);
            outputList("myFirstList.AddRange(list2), myFirstList", myFirstList);


            myFirstList.AddRange(arr);
            outputList("myFirstList.AddRange(arr), myFirstList", myFirstList);

            List<string> strl = new List<string> { "stuff", "thingy" };
            //myFirstList.AddRange(strl);

            list2.Insert(0, 0);
            outputList("list2.Insert(0, 0), list2", list2);

            list2.Insert(2, 999);
            outputList("list2.Insert(2, 999), list2", list2);

            Console.WriteLine("list2.Count: " + list2.Count);
            Console.WriteLine("list2.Capacity: " + list2.Capacity);

            Console.WriteLine("list2.Contains(0): " + list2.Contains(0));
            Console.WriteLine("list2.Contains(777): " + list2.Contains(777));

            Console.WriteLine("list2.Find: " + list2.Find(x => x > 3));
            outputList("list2.FindAll", list2.FindAll(x => x > 99));

            int[] toar = list2.ToArray();

            list2.Clear();
            outputList("list2.Clear(), list2", list2);


            // DICTIONARY //
            Dictionary<int, string> stud = new Dictionary<int, string>();

            stud.Add(1, "Jan");
            stud.Add(2, "Kristina");
            stud.Add(3, "Karel");
            stud.Add(4, "Martin");
            stud.Add(5, "Petra");
            stud.Add(6, "Owen");

            //Dictionary<List<int>, string> crazySh;

            Console.WriteLine("stud[1]: " + stud[1]);

            Dictionary<string, string> fava = new Dictionary<string, string>();

            fava.Add("Misi", "sloth");
            fava.Add("Jan", "dog");
            fava.Add("Kristina", "rat");
            fava.Add("Karel", "mosquito");
            fava.Add("Martin", "cat");
            fava.Add("Petra", "cow");
            fava.Add("Owen", "panda");

            Console.WriteLine("fava[stud[3]]: " + fava[stud[3]]);

            Dictionary<string, int> mtemp = new Dictionary<string, int>();

            mtemp.Add("January", 2);
            mtemp.Add("February", 5);
            mtemp.Add("March", 10);
            mtemp.Add("April", 17);

            //KeyValuePair<string, int> may = new KeyValuePair<string, int>("May", 20);

            foreach (KeyValuePair<string, int> month in mtemp)
            {
                Console.WriteLine("Average temprature in " + month.Key +
                                  " is " + month.Value + "°C");
            }

        }


        static void outputList(string prefix, List<string> list)
        {
            Console.Write(prefix + ": ");
            Console.Write("[");
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write("\"" + list[i] + "\"");
                if (i < list.Count - 1) Console.Write(", ");
            }
            Console.WriteLine("]");
        }
        static void outputList(string prefix, List<int> list)
        {
            Console.Write(prefix + ": ");
            Console.Write("[");
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write("\"" + list[i] + "\"");
                if (i < list.Count - 1) Console.Write(", ");
            }
            Console.WriteLine("]");
        }
    }
}
