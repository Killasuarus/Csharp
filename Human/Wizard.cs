using System;
namespace Human
{
    public class Wizard:Human
    {
        public Wizard() : base("Gandolf")
        {
            health = 50;
            intelligence = 25;
        }

        public void Heal()
        {
            health += intelligence*10;
        }

        public void Fireball(object obj)
        {
            Random rand = new Random();
            Human enemy = obj as Human;
            if(enemy == null)
            {
                Console.WriteLine("Fizzle");
            }
            else
            {
                enemy.health -= rand.Next(20,50);
            }
        }
    }
}
