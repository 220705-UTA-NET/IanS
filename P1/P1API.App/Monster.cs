namespace P1API.App
{
    public class Monster
    {
        public int id { get; set; }
        public int health { get; set;}
        public string? name { get; set; }
        public int attackMax { get; set; }
        Random random = new Random();

        public Monster () { }

        public Monster(int health, string? name, int attackMax)
        {
            this.health = health;
            this.name = name;
            this.attackMax = attackMax;
        }

        public Monster(int id, int health, string? name, int attackMax)
        {
            this.id = id;
            this.health = health;
            this.name = name;
            this.attackMax = attackMax;
        }

        public bool healthCheck()
        {
            if (this.health <= 0)
            {
                return false;
            }
            return true;
        }

        public int attack(int attackMax)
        {
            int mAttack = random.Next(1, attackMax);
            Console.WriteLine(this.name + " attacks for: " + mAttack + "!");
            return (mAttack);
        }

        public int defendRoll(int attack)
        {
            int block = random.Next(1, attackMax);
            this.health -= (attack - block);

            if (attack > block)
            {
                Console.WriteLine(this.name + " blocks for: " + block);
                Console.WriteLine(this.name + " takes " + (attack - block) + " damage.");
                return (this.health);
            }
            else if (attack == 0)
            {
                Console.WriteLine(this.name + " blocks for: " + block);
                Console.WriteLine(this.name + " stares awkwardly at you.");
            }
            else
            {
                Console.WriteLine(this.name + " blocks for: " + block);
                Console.WriteLine("Blocked");
            }

            return this.health;
        }

        public int monChoice(int pAttack)
        {

            int choice = random.Next(1, 6);

            if (choice >= 3)
            {
                Console.WriteLine(this.name + " remaining health: " + (this.health -= pAttack));
                
                if (!this.healthCheck())
                {
                    Console.WriteLine(this.name + " has died!");
                    return 0;
                }
                
                return (attack(this.attackMax));
            }
            else
            {
                Console.WriteLine(this.name + " defends!");
                this.health = defendRoll(pAttack);
                return 0;
            }
        }
    }
}