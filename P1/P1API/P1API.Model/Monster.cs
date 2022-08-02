namespace P1API.Model
{
    public class Monster
    {
        // Fields
        public int Id { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }
        public int AttackMax { get; set; }

        // Constructor
        public Monster() { }

        //public Monster(string name, int health, int attackMax)
        //{
        //    Name = name;
        //    Health = health;
        //    AttackMax = attackMax;
        //}

        public Monster(int id, string name, int health, int attackMax)
        {
            Id = id;
            Name = name;
            Health = health;
            AttackMax = attackMax;
        }
    }
}