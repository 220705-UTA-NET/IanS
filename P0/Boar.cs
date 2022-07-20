using System;

namespace Project0
{
    class Boar : Character
    {
        public Boar()
        {
            this.health = 15;
            this.name = "Boar";
        }

        new public int attack()
        {
            int sAttack = dice.boarRoll();
            Console.WriteLine(this.name + " attacks for: " + sAttack + "!");
            return (sAttack);
        }

        new public int defendRoll(int attack)
        {
            int block = dice.boarRoll();
            int slimeHealth = this.health -= (attack - block);

            if (attack > block)
            {
                Console.WriteLine("Boar blocks for: " + block);
                Console.WriteLine("Boar takes " + (attack - block) + " damage.");
                return (this.health -= attack);
            }
            else
            {
                Console.WriteLine("Blocked");
            }

            return this.health;
        }

        public int monChoice(int pAttack)
        {

            int choice = dice.roll();

            if (choice >= 3)
            {
                Console.WriteLine("Boar remaining health: " + (this.health -= pAttack));
                
                if (!this.healthCheck())
                {
                    Console.WriteLine("Boar has died!");
                    return 0;
                }
                
                return (attack());
            }
            else
            {
                Console.WriteLine("Boar defends!");
                this.health = defendRoll(pAttack);
                return 0;
            }
        }
    }
}