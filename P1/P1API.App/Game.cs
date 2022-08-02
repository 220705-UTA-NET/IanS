using System;
using System.Text.RegularExpressions;

namespace P1API.App
{
    class Game
    {
        bool menuChoice = true;
        Random random = new Random();

        public async Task mainMenu()
        {
            while (menuChoice)
            {
                Console.WriteLine("Welcome to the Game!");
                Console.WriteLine("------------------------------------------");
                Console.WriteLine("|                                        |");
                Console.WriteLine("|       Press '1' to Start Game          |");
                Console.WriteLine("|  Press '2' to Create Your Own Monster  |");
                Console.WriteLine("|  Press '3' to Look at all monsters     |");
                Console.WriteLine("|          Press '4' to Quit             |");
                Console.WriteLine("|                                        |");
                Console.WriteLine("------------------------------------------");

                switch (Console.ReadLine())
                {
                    case "1":
                    {
                        menuChoice = false;
                        await startGame();
                        break;
                    }
                    case "2":
                    {
                        Console.WriteLine("Forgive me this is under construction.");
                        menuChoice = false;
                        // Monster createdMonster = createMonster();
                        // Console.WriteLine("Monster name: " + createdMonster.name);
                        // Console.WriteLine("Monster health: " + createdMonster.health);
                        // Console.WriteLine("Monster attackMax: " + createdMonster.attackMax);

                        // await MonsterController.AddMonster(createdMonster);

                        break;
                    }
                    case "3":
                    {
                        List<MonsterDTO> monsters = await MonsterController.GetMonstersReady();
                        foreach(var item in monsters)
                        {
                            Console.WriteLine(item.ToString());
                        }

                        Console.WriteLine("Are you looking for a specific monster?");
                        Console.WriteLine("-----------------------------");
                        Console.WriteLine("|                            |");
                        Console.WriteLine("|       Press '1' Yes        |");
                        Console.WriteLine("|       Press '2' No         |");
                        Console.WriteLine("|                            |");
                        Console.WriteLine("------------------------------");
                        
                        bool stillLooking = true;

                        while (stillLooking)
                        {

                            string choice = Console.ReadLine();
                            switch(choice)
                            {
                                case "1":
                                {   
                                    List<MonsterDTO> monsters2 = await MonsterController.GetMonstersReady();
                                    foreach(var item in monsters2)
                                    {
                                        Console.WriteLine(item.ToString());
                                    }
                                    int chooseMon = checkPlayerChoiceMonster();
                                    Monster monChoice = await MonsterController.GetOneMonster(chooseMon);
                                    Console.WriteLine  ("Monster Id: " + monChoice.id);
                                    Console.WriteLine  ("Monster Name: " + monChoice.name);
                                    Console.WriteLine  ("Monster Health: " + monChoice.health);
                                    Console.WriteLine  ("Monster Max Damage: " + monChoice.attackMax);
                                    
                                    // Console.WriteLine("\nKeep looking?");
                                    // Console.WriteLine("-----------------------------");
                                    // Console.WriteLine("|                            |");
                                    // Console.WriteLine("|       Press '1' Yes        |");
                                    // Console.WriteLine("|       Press '2' No         |");
                                    // Console.WriteLine("|                            |");
                                    // Console.WriteLine("------------------------------");

                                    // string c = Console.ReadLine();
                                    // switch(c)
                                    // {
                                    //     case "1":
                                    //     {
                                    //         stillLooking = true;
                                    //         break;
                                    //     }
                                    //     case "2":
                                    //     {
                                    //         stillLooking = false;
                                    //         break;
                                    //     }
                                    //     default:
                                    //     {
                                    //         Console.WriteLine("Invalid input please try again.2");
                                    //         stillLooking = true;
                                    //         break;
                                    //     }
                                    // }
                                    
                                    stillLooking = false;
                                    break;
                                }
                                case "2":
                                {
                                    stillLooking = false;
                                    break;
                                }
                                default:
                                {
                                    Console.WriteLine("Invalid input please try again.");
                                    stillLooking = true;
                                    break;
                                }
                            }
                        }
                        menuChoice = false;
                        break;
                    }
                    case "4":
                    {
                        menuChoice = false;
                        break;
                    }
                    default:
                    {
                        Console.WriteLine("Incorrect input please try again");
                        break;
                    }
                }
            }
        }

        private string? getUserName()
        {
            string? name;

            do
            {
                Console.WriteLine("Enter Name: ");
                name = Console.ReadLine();

                if (Regex.IsMatch(name, @"\W") || Regex.IsMatch(name, @"\d"))
                {
                    Console.WriteLine("Invalid character. Please enter an alphabetic name.");
                }
                else if (name.Length < 3 || name == null)
                {
                    Console.WriteLine("Invalid name. Must be at least 3 letter long.");
                }

            } while (name.Length < 3 || name == null || Regex.IsMatch(name, @"\W") || Regex.IsMatch(name, @"\d"));

            return name;
        }

        public async Task startGame()
        {
            Console.WriteLine("Game Started");

            Character player = new Character(getUserName());

            Console.WriteLine("Player name: " + player.name);

            Arena arena = new Arena();

            Monster m = await MonsterController.GetOneMonster(1);

            Console.WriteLine("Welcome " + player.name);
            Console.WriteLine("Be prepared for your first challenge: " + m.name + "!");

            arena.arenaBattle(player, m);

            bool stillInFight = true;

            do
            {
                if (!player.healthCheck())
                {
                    Console.WriteLine("You're dead!!");
                    stillInFight = false;
                    break;
                }

                Console.WriteLine("Would you like to play again?");
                Console.WriteLine("-------------------------");
                Console.WriteLine("|                       |");
                Console.WriteLine("|   (1) to play again   |");
                Console.WriteLine("|     (2) to quit       |");
                Console.WriteLine("|                       |");
                Console.WriteLine("-------------------------");

                switch (Console.ReadLine())
                {
                    case "1":
                    {
                        Console.WriteLine("Get ready to fight " + player.name + "!!");
                        
                        int monRoullete = random.Next(1, 6);
                        
                        // GetSingle monster function and place them in arena
                        Monster monster = await MonsterController.GetOneMonster(monRoullete);
                        Console.WriteLine("Bring out the " + monster.name + "!!");
                        arena.arenaBattle(player, monster);

                        break;
                    }
                    case "2":
                    {
                        stillInFight = false;
                        Console.WriteLine("Goodbye!");
                        break;
                    }
                    default:
                    {
                        Console.WriteLine("Incorrect input please try again");
                        break;
                    }
                }
            } while (stillInFight);

            Console.WriteLine("Your final kill count!: " + player.killCount + " monsters.");
        }

        public Monster createMonster()
        {
            Monster newMonster = new Monster();
            Console.WriteLine("Let's create a monster!");

            newMonster.name = checkName();
            newMonster.health = checkHealth();
            newMonster.attackMax = checkAttackMax();

            return newMonster;
        }

        public string checkName()
        {
            string check;
            do
            {
                Console.WriteLine("Enter name or type of monster: ");
                check = Console.ReadLine();

                if (Regex.IsMatch(check, @"\W") || Regex.IsMatch(check, @"\d"))
                {
                    Console.WriteLine("Invalid character. Please enter an alphabetic name.");
                }
                else if (check.Length < 3 || check == null)
                {
                    Console.WriteLine("Invalid name. Must be at least 3 letter long.");
                }

            } while (check.Length < 3 || check == null || Regex.IsMatch(check, @"\W") || Regex.IsMatch(check, @"\d"));

            return check;
        }

        public int checkHealth()
        {
            
            string check;
            int checkInt = 101;

            do
            {
                Console.WriteLine("Enter how much health it'll have: ");
                check = Console.ReadLine();

                if (check.Length < 1)
                {
                    Console.WriteLine("Invalid health input. Health can not be empty.");
                }
                else if (Regex.IsMatch(check, @"\W") || Regex.IsMatch(check, @"[a-zA-z]"))
                {
                    Console.WriteLine("Invalid character. Please enter an integer number.");
                }
                else
                {
                    checkInt = Int32.Parse(check);

                    if (checkInt > 100)
                    {
                        Console.WriteLine("Health too great. Please enter an integer less than or equal to 100");
                    }
                }
            } while (
                check.Length < 1 || 
                check == null || 
                Regex.IsMatch(check, @"\W") || 
                Regex.IsMatch(check, @"[a-zA-z]") || 
                checkInt > 100);

            return checkInt;
        }

        public int checkAttackMax()
        {
            
            string check;
            int checkInt = 7;
            do
            {
                Console.WriteLine("Enter the max amount of damage you'd like your monster to do: ");
                Console.WriteLine("~Note: 6 will be the max amount of damage you can enter for damage for now.~");
                check = Console.ReadLine();

                if (check.Length < 1)
                {
                    Console.WriteLine("Invalid input. Damage can not be empty.");
                }
                else if (Regex.IsMatch(check, @"\W") || Regex.IsMatch(check, @"[a-zA-z]"))
                {
                    Console.WriteLine("Invalid character. Please enter an integer number.");
                }
                else
                {
                    checkInt = Int32.Parse(check);

                    if (checkInt > 6)
                    {
                        Console.WriteLine("Attack damage too great. Please enter an integer less than or equal to 6");
                    }
                }
            } while (
                check.Length < 1 || 
                check == null || 
                Regex.IsMatch(check, @"\W") || 
                Regex.IsMatch(check, @"[a-zA-z]") || 
                checkInt > 6);

            return checkInt;
        }
        public int checkPlayerChoiceMonster()
        {
            
            string check;
            int checkInt = 7;
            do
            {
                Console.WriteLine("What monster would you like to look at specifically?");
                Console.WriteLine("~Note: There are currently only 6 total monsters for now.~");
                check = Console.ReadLine();

                if (check.Length < 1)
                {
                    Console.WriteLine("Invalid input. Damage can not be empty.");
                }
                else if (Regex.IsMatch(check, @"\W") || Regex.IsMatch(check, @"[a-zA-z]"))
                {
                    Console.WriteLine("Invalid character. Please enter an integer number.");
                }
                else
                {
                    checkInt = Int32.Parse(check);

                    if (checkInt > 6)
                    {
                        Console.WriteLine("Attack damage too great. Please enter an integer less than or equal to 6");
                    }
                }
            } while (
                check.Length < 1 || 
                check == null || 
                Regex.IsMatch(check, @"\W") || 
                Regex.IsMatch(check, @"[a-zA-z]") || 
                checkInt > 6);

            return checkInt;
        }
    }
}