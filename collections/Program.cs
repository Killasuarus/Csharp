using System;
using System.Collections.Generic;

namespace collections
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] num = {0,1,2,3,4,5,6,7,8,9};
            // Console.WriteLine(num);
            // Console.WriteLine(num[4]);

            string[] starr = {"Tim", "Martin", "Nikki", "Sara"};
            bool[] boo = {true,false,true,false,true,false,true,false,true,false};
            int[,] mult = new int[10,10];
            for(int x = 0; x < 10; x++)
            {
                for(int y = 0; y < 10; y++)
                {
                    mult[x, y] = (x + 1) * (y + 1);
                }
            }
            List<string> flavors = new List<string>();
            flavors.Add("vanilla");
            flavors.Add("chocolate");
            flavors.Add("strawberry");
            flavors.Add("poo");
            flavors.Add("bear meat");
            Console.WriteLine(flavors.Count);
            Console.WriteLine(flavors[2]);
            flavors.Remove(flavors[2]);
            Console.WriteLine(flavors.Count);
            Dictionary<string,string> names = new Dictionary<string,string>();
            for(int i = 0; i < starr.Length; i++)
            {
                names.Add(starr[i], "null");
                Console.WriteLine(starr[i]);
            }
            Random rand = new Random();
            foreach(string entry in flavors)
            {
                names[entry] = flavors[rand.Next(flavors.Count)];
            }
            
        }
    }
}
