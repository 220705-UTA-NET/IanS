namespace P1API.App
{
    public class Dice
    {
        Random random = new Random();
        public int roll()
        {
            return random.Next(1, 7);
        }

        public int slimeRoll()
        {
            return random.Next(1, 4);
        }

        public int boarRoll()
        {
            return random.Next(1, 5);
        }

        public int coinflip()
        {
            return random.Next(1, 3);
        }
    }
}