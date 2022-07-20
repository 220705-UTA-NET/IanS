using System;

namespace Project0
{
    class Arena
    {
        public void arenaBattleSlime(Character p)
        {
                Slime s = new Slime();
            
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
                            int mAttack = s.monChoice(p.attack());

                            if (!s.healthCheck())
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
                            p.defendRoll(s.monChoice(0));
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

        public void arenaBattleBoar(Character p)
        {
                Boar b = new Boar();
            
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
                            int mAttack = b.monChoice(p.attack());

                            if (!b.healthCheck())
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
                            p.defendRoll(b.monChoice(0));
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