namespace P1API.Model
{
    public class Monster
    {
        // Fields
        public int Id { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }

        // Constructor

        public Monster() { }

        public Monster(int id, string name, int health)
        {
            Id = id;
            Name = name;
            Health = health;
        }

        // Methods
    }
}