namespace P1API.App
{
    class MonsterDTO
    {
        // Fields
        public int id { get; set; }
        public string name { get; set; }
        public int health { get; set; }
        public int attackMax { get; set; }

        // Constructor
        public MonsterDTO() {}

        public MonsterDTO(int id, string name, int health, int attackMax)
        {
            this.id = id;
            this.name = name;
            this.health = health;
            this.attackMax = attackMax;
        }

        // Methods
        public override string ToString()
        {
            return $"{id} {name}";
        }

    }
}