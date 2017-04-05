using System;
namespace Human
{
    public class Ninja:Human
    {
        public Ninja():base("Genji")
        {
            dexterity = 175;
        }
        public void Steal(object obj)
        {
            Human enemy = obj as Human;
            if(enemy == null)
            {
                Console.WriteLine("Failed To Steal");
            }
            else
            {
                enemy.health -= strength * 5;
                health += dexterity/10;
            }
        }

        public void Flee()
        {
            health -= 10;
        }
    }
}