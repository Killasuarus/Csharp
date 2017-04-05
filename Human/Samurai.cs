using System;
namespace Human
{
    public class Samurai:Human
    {
        public Samurai():base("Tom Cruise")
        {
            health = 200;
        }

        public void DeathBlow(object obj)
        {
            Human enemy = obj as Human;
            if(enemy==null)
            {
                Console.WriteLine("You can't kill what's already dead");
            }
            else
            {
                if(enemy.health < 50)
                {
                    enemy.health = 0;
                }
            }
        }
        public void Meditate()
        {
            health = 200;
        }
    }
}