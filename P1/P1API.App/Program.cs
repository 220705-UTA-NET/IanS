

namespace P1API.App
{
    class Program
    {   
        public static async Task Main()
        {
            Game game = new Game();
            await game.mainMenu();
        }
    }
}
