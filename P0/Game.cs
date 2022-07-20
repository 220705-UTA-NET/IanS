using System;
using System.Text.RegularExpressions;

namespace Project0
{
    class Game
    {
        bool menuChoice = true;
        Dice coin = new Dice();

        public void mainMenu()
        {
            while (menuChoice)
            {
                Console.WriteLine("Welcome to the Game!");
                Console.WriteLine("-------------------------");
                Console.WriteLine("|                       |");
                Console.WriteLine("|Press '1' to Start Game|");
                Console.WriteLine("|   Press '2' to Quit   |");
                Console.WriteLine("|                       |");
                Console.WriteLine("-------------------------");

                switch (Console.ReadLine())
                {
                    case "1":
                    {
                        menuChoice = false;
                        startGame();
                        break;
                    }
                    case "2":
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

        public void startGame()
        {
            Console.WriteLine("Game Started");

            Character player = new Character(getUserName());

            Console.WriteLine("Player name: " + player.name);

            Arena arena = new Arena();

            arena.arenaBattleSlime(player);

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
                        
                        switch(coin.coinflip())
                        {
                            case 1:
                            {
                                Console.WriteLine("Bring out the slime!!");
                                arena.arenaBattleSlime(player);
                                break;
                            }
                            case 2:
                            {
                                Console.WriteLine("Bring out the boar!!");
                                arena.arenaBattleBoar(player);
                                break;
                            }
                            default:
                            {
                                break;
                            }
                        }
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
    }
}