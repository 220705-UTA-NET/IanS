using Microsoft.Extensions.Logging;
using P1API.Model;
using System.Data.SqlClient;

namespace P1API.Data
{
    public class SQLRepository : IRepository
    {
        // Fields
        private readonly string _connectionString;
        private readonly ILogger<SQLRepository> _logger;

        // Constructor
        public SQLRepository(string connectionString, ILogger<SQLRepository> logger)
        {
            _connectionString = connectionString;
            _logger = logger;
        }

        // Methods
        public async Task<IEnumerable<Monster>> GetAllMonstersAsync()
        {
            List<Monster> result = new();

            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            string cmdText = "SELECT mon_id, mon_name, mon_health FROM PROJ1.Monster;";

            using SqlCommand cmd = new(cmdText, connection);

            using SqlDataReader reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                int health = reader.GetInt32(2);

                Monster tmpMonster = new Monster(id, name, health);
                result.Add(tmpMonster);
            }

            await connection.CloseAsync();

            _logger.LogInformation("Executed GetAllAssociatesAsync, returned {0} results", result.Count);

            return result;
        }
    }
}