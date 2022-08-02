using Microsoft.Extensions.Logging;
using P1API.Model;
using System.Data.SqlClient;

namespace P1API.Data
{
    public class SQLRepositoryMonster : IRepositoryMonster
    {
        // Fields
        private readonly string _connectionString;
        private readonly ILogger<SQLRepositoryMonster> _logger;

        // Constructor
        public SQLRepositoryMonster(string connectionString, ILogger<SQLRepositoryMonster> logger)
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

            string cmdText = "SELECT mon_id, mon_name, mon_health, mon_attackMax FROM PROJ1.Monster;";

            using SqlCommand cmd = new(cmdText, connection);

            using SqlDataReader reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                int health = reader.GetInt32(2);
                int attackMax = reader.GetInt32(3);

                Monster tmpMonster = new Monster(id, name, health, attackMax);
                result.Add(tmpMonster);
            }

            await connection.CloseAsync();

            _logger.LogInformation("Executed GetAllMonstersAsync, returned {0} results", result.Count);

            return result;
        }

        public async Task<Monster> GetMonsterByIdAsync(int id)
        {
            using SqlConnection connection = new(_connectionString);
            
            await connection.OpenAsync();

            string cmdText = @"SELECT mon_id, mon_name, mon_health, mon_attackMax
                             FROM PROJ1.Monster
                             WHERE mon_id = @id;";

            using SqlCommand cmd = new(@cmdText, connection);
            cmd.Parameters.AddWithValue("@id", id);

            using SqlDataReader reader = await cmd.ExecuteReaderAsync();

            reader.Read();

            string name = reader.GetString(1);
            int health = reader.GetInt32(2);
            int attackMax = reader.GetInt32(3);

            Monster result = new Monster(id, name, health, attackMax);

            await connection.CloseAsync();

            return result;
        }

        public void AddMonsterRepo(Monster monster)
        {
            using SqlConnection connection = new(_connectionString);

            connection.Open();

            string cmdText = @"INSERT INTO PROJ1.Monster (mon_name, mon_health, mon_attackMax)
                                VALUES
                                (@name, @health, @attackMax);";

            using SqlCommand cmd = new(@cmdText, connection);
            cmd.Parameters.AddWithValue("@name", monster.Name);
            cmd.Parameters.AddWithValue("@health", monster.Health);
            cmd.Parameters.AddWithValue("@attackMax", monster.AttackMax);

            cmd.ExecuteNonQuery();

            connection.Close();
        }

        public void UpdateMonsterAsync(int id, Monster updateMonster)
        {
            using SqlConnection connection = new(_connectionString);

            connection.Open();

            string cmdText = @"UPDATE PROJ1.Monster
                               SET
                                   mon_name = @name,
                                   mon_health = @health
                               WHERE mon_id = @id;";

            using SqlCommand cmd = new(@cmdText, connection);
            cmd.Parameters.AddWithValue("@name", updateMonster.Name);
            cmd.Parameters.AddWithValue("@health", updateMonster.Health);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            //using SqlDataReader reader = cmd.ExecuteReader();

            //reader.Read();

            //string nameUpdate = reader.GetString(1);
            //int healthUpdate = reader.GetInt32(2);

            //Monster result = new Monster(id, nameUpdate, healthUpdate);

            connection.Close();
        }

        public void DeleteMonster(int id)
        {
            using SqlConnection connection = new(_connectionString);

            connection.Open();

            string cmdText = @"DELETE
                               FROM PROJ1.Monster
                               WHERE mon_id = @id;

                               DECLARE @max int
                               SELECT @max=MAX([mon_id])
                               FROM PROJ1.Monster
                               IF @max IS NULL
                                   SET @max = 0
                               DBCC CHECKIDENT ('PROJ1.Monster', RESEED, @max);";

            using SqlCommand cmd = new(@cmdText, connection);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            connection.Close();
        }
    }
}