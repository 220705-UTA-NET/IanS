using System.Text;
using System.Text.Json;

namespace P1API.App
{
    class MonsterController
    {
        public static string uri = "https://localhost:7230/api/Monster";
        public static readonly HttpClient client = new HttpClient();

        public static async Task<List<MonsterDTO>> GetMonstersReady()
        {
            string response = await client.GetStringAsync(uri);
            List<MonsterDTO> monsters = JsonSerializer.Deserialize<List<MonsterDTO>>(response);

            return monsters;
        }
        public static async Task<Monster> GetOneMonster(int chosenMonster)
        {
            string response = await client.GetStringAsync(uri + "/" + chosenMonster);
            Monster monster = JsonSerializer.Deserialize<Monster>(response);

            return monster;
        }

        public static async Task AddMonster(Monster monster)
        {
            var content = new StringContent(JsonSerializer.Serialize(monster), Encoding.UTF8, "application/json");
            await client.PostAsync(uri, content);
        }
    }
}