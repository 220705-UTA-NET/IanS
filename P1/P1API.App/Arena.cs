using System.Text.Json;

namespace P1API.App
{
    class Arena
    {
        public void arenaBattle(Character p, Monster m)
        {
            bool commited = true;

            do
            {
                Console.WriteLine("-------------------------");
                Console.WriteLine("|                       |");
                Console.WriteLine("|     (1) to Attack     |");
                Console.WriteLine("|     (2) to Defend     |");
                Console.WriteLine("|                       |");
                Console.WriteLine("-------------------------");
                
                
                switch (Console.ReadLine())
                {
                    case "1":
                    {
                        int mAttack = m.monChoice(p.attack());

                        if (!m.healthCheck())
                        {
                            p.killCount += 1;
                            commited = false;
                            break;
                        }

                        p.health -= mAttack;
                        Console.WriteLine("Your remaining health is: " + p.health);
                        break;
                    }
                    case "2":
                    {
                        p.defendRoll(m.monChoice(0));
                        Console.WriteLine("Your remaining health is: " + p.health);
                        break;
                    }
                    default:
                    {
                        Console.WriteLine("Incorrect input please try again");
                        break;
                    }
                }

                if (!(p.healthCheck()))
                {
                    commited = false;
                    Console.WriteLine(p.name + " has died!");
                }

            } while (commited);
        }
    }
}