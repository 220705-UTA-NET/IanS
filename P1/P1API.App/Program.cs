using System.Text.Json;

namespace P1API.App
{
    class Program
    {   
        public static readonly HttpClient client = new HttpClient();
        public static string uri = "https://localhost:7230/api/Monster";
        
        static async Task Main()
        {
            string response = await client.GetStringAsync(uri);

            List<MonsterDTO> monsters = JsonSerializer.Deserialize<List<MonsterDTO>>(response);

            foreach (var m in monsters)
            {
                Console.WriteLine(m.ToString());
            }
        }
    }
}
