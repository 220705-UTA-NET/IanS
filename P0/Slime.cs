using System;

namespace Project0
{
    class Slime : Character
    {
        public Slime()
        {
            this.health = 10;
            this.name = "Slime";
        }

        new public int attack()
        {
            int sAttack = dice.slimeRoll();
            Console.WriteLine(this.name + " attacks for: " + sAttack + "!");
            return (sAttack);
        }

        new public int defendRoll(int attack)
        {
            int block = dice.slimeRoll();
            int slimeHealth = this.health -= (attack - block);

            if (attack > block)
            {
                Console.WriteLine("Slime blocks for: " + block);
                Console.WriteLine("Slime takes " + (attack - block) + " damage.");
                return (slimeHealth);
            }
            else
            {
                Console.WriteLine("Slime blocks for: " + block);
                Console.WriteLine("Blocked");
            }

            return this.health;
        }

        public int monChoice(int pAttack)
        {

            int choice = dice.roll();

            if (choice >= 3)
            {
                Console.WriteLine("Slime remaining health: " + (this.health -= pAttack));
                
                if (!this.healthCheck())
                {
                    Console.WriteLine("Slime has died!");
                    return 0;
                }
                
                return (attack());
            }
            else
            {
                Console.WriteLine("Slime defends!");
                this.health = defendRoll(pAttack);
                return 0;
            }
        }
    }
}