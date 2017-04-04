using System;

namespace Human
{
    class Program
    {
        static void Main(string[] args)
        {
            Human Eli = new Human("Elias");
            Human Dylan = new Human("Dylan");
            Console.WriteLine(Dylan.health);
            Eli.Attack(Dylan);
            Console.WriteLine(Dylan.health);
            Eli.Attack(Dylan);
            
        }
    }
}
