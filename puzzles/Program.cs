using System;
using System.Collections.Generic;

namespace puzzles
{
    class Program
    {
        public static Random rand = new Random();
        public static int[] RandomArray()
        {
            int[] randomArr = new int[10];
            int min = new int();
            int max = randomArr[0];
            int sum = new int();
            for(int i = 0; i < randomArr.Length; i++)
            {
                randomArr[i] = rand.Next(5,26);
                if(randomArr[i] < min)
                {
                    min = randomArr[i];
                }
                if(randomArr[i] > max)
                {
                    max = randomArr[i];
                }
                sum += randomArr[i];
            }
            Console.WriteLine("Sum = {0}, Min = {1}, Max = {2}", sum, min, max);
            return randomArr;
            
        } 
        public static string TossCoin(Random rand)
        {
            string coin = "";
            int result = rand.Next(0,2);
            if(result == 0)
            {
                Console.WriteLine("You flipped a Heads");
                coin = "Heads";
            }
            else
            {
                Console.WriteLine("You flipped a Tails");
                coin = "Tails";
            }
            return coin;
        }
        
        public static double TossMultipleCoins(int num)
        {
            int heads = 0;
            int tails = 0;
            for(int i = 0; i < num; i++)
            {
                string coin = TossCoin(rand);
                if(coin == "Heads")
                {
                    heads += 1;
                }
                else
                {
                    tails += 1;
                }
            }
            double ratio = (double)heads/tails;
            Console.WriteLine(ratio);
            return ratio;
        }

        public static string[] Names() {
            string[] names = new string[5] {"Dylan","Eddy","Chuck","Ashley","Rachel"};
            for(var i = 0; i < names.Length - 1; i++){
                int randIdx = rand.Next(i + 1, names.Length - 1);
                string temp = names[i];
                names[i] = names[randIdx];
                names[randIdx] = temp;
                Console.WriteLine(names[i]);
            }
            Console.WriteLine(names[names.Length - 1]);

            List<string> nameList = new List<string>();
            for(var i = 0; i < names.Length; i++)
            {
                if(names[i].Length > 5)
                {
                    nameList.Add(names[i]);
                }
            }
            return nameList.ToArray();
        }
        static void Main(string[] args)
        {
            RandomArray();
            TossCoin(rand);
            TossMultipleCoins(10);
            Console.WriteLine(Names());
        }
    }
}
