using System;
using System.Collections.Generic;

namespace boxing
{
    class Program
    {
        static void Main(string[] args)
        {
           List<object> myList = new List<object>();
            myList.Add(7);
            myList.Add(28);
            myList.Add(-1);
            myList.Add(true);
            myList.Add("chair");
            // Console.WriteLine(myList.Count);
            int sum = new int();
            for(int i = 0; i < myList.Count; i++)
            {
                // Console.WriteLine(myList[i]);
                if(myList[i] is int)
                {
                    sum += (int)myList[i]; 
                }
            }
            Console.WriteLine(sum);

        }
    }
}
