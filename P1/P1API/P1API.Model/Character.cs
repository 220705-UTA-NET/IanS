namespace P1API.Model
{
    public class Character
    {
        // Fields
        public int Id { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }
        public int KillCount { get; set; }

        // Constructor
        public Character() { }

        public Character(string name, int killCount)
        {
            Name = name;
            KillCount = killCount;
        }

        public Character(int id, string name, int health, int killCount)
        {
            Id = id;
            Name = name;
            Health = health;
            KillCount = killCount;
        }
    }
}
