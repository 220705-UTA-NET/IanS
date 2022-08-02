using System;

namespace P1API.App
{
    class Character
    {
        public int health { get; set; }
        public int killCount = 0;
        public string? name {get; set;}
        public Dice dice = new Dice();
        
        
        public Character(string? name)
        {
            this.name = name;
            this.health = 100;
        }

        public Character() 
        {

        }

        public int attack()
        {
            int cAttack = dice.roll();
            Console.WriteLine("You attack for: " + cAttack + "!");
            return cAttack;
        }

        public int defendRoll(int mAttack)
        {
            int dRoll = dice.roll();

            if (mAttack > dRoll)
            {
                Console.WriteLine("You defend for: " + dRoll);
                int defenceResult = this.health -= (mAttack - dRoll);
                Console.WriteLine("You take " + defenceResult + " damage.");
                return (defenceResult);
            }
            else if (mAttack == 0)
            {
                Console.WriteLine("You stare at each other in silence...");
                
            }
            else 
            {
                Console.WriteLine("Blocked");
            }

            return this.health;
        }

        public bool healthCheck()
        {
            if (this.health <= 0)
            {
                return false;
            }
            return true;
        }
    }
}