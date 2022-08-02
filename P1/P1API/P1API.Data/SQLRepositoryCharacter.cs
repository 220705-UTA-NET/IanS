using Microsoft.Extensions.Logging;
using P1API.Model;
using System.Data.SqlClient;

namespace P1API.Data
{
    public class SQLRepositoryCharacter : IRepositoryCharacter
    {
        // Fields
        private readonly string _connectionString;
        private readonly ILogger<SQLRepositoryCharacter> _logger;

        // Constructor
        public SQLRepositoryCharacter(string connectionString, ILogger<SQLRepositoryCharacter> logger)
        {
            _connectionString = connectionString;
            _logger = logger;
        }

        // Methods
        public async Task<IEnumerable<Character>> GetAllCharactersAsync()
        {
            List<Character> result = new();

            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            string cmdText = @"SELECT char_id, char_name, char_health, char_killcount
                                FROM PROJ1.Character; ";

            using SqlCommand cmd = new(cmdText, connection);

            using SqlDataReader reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                int health = reader.GetInt32(2);
                int killCount = reader.GetInt32(3);

                Character tmpCharacter = new Character(id, name, health, killCount);
                result.Add(tmpCharacter);
            }

            await connection.CloseAsync();

            _logger.LogInformation("Executed GetAllCharactersAsync, returned {0} results", result.Count);

            return result;
        }

        public async Task<Character> GetCharacterByIdAsync(int id)
        {
            using SqlConnection connection = new(_connectionString);

            await connection.OpenAsync();

            string cmdText = @"SELECT char_id, char_name, char_health, char_killcount
                               FROM PROJ1.Character
                               WHERE char_id = @id;";

            using SqlCommand cmd = new(@cmdText, connection);
            cmd.Parameters.AddWithValue("@id", id);

            using SqlDataReader reader = await cmd.ExecuteReaderAsync();

            reader.Read();

            string name = reader.GetString(1);
            int health = reader.GetInt32(2);
            int killCount = reader.GetInt32(3);

            Character result = new Character(id, name, health, killCount);

            await connection.CloseAsync();

            return result;
        }

        public void AddCharacterRepo(Character character)
        {
            using SqlConnection connection = new(_connectionString);

            connection.Open();

            string cmdText = @"INSERT INTO PROJ1.Character (char_name, char_health)
                                VALUES
                                (@name, @health);";

            using SqlCommand cmd = new(@cmdText, connection);
            cmd.Parameters.AddWithValue("@name", character.Name);
            cmd.Parameters.AddWithValue("@health", character.Health);

            cmd.ExecuteNonQuery();

            connection.Close();
        }

        public void UpdateCharacterAsync(int id, Character updateCharacter)
        {
            using SqlConnection connection = new(_connectionString);

            connection.Open();

            string cmdText = @"UPDATE PROJ1.Character
                               SET
                                   char_name = @name,
                                   char_health = @health
                               WHERE char_id = @id;";

            using SqlCommand cmd = new(@cmdText, connection);
            cmd.Parameters.AddWithValue("@name", updateCharacter.Name);
            cmd.Parameters.AddWithValue("@health", updateCharacter.Health);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            //using SqlDataReader reader = cmd.ExecuteReader();

            //reader.Read();

            //string nameUpdate = reader.GetString(1);
            //int healthUpdate = reader.GetInt32(2);

            //Character result = new Character(id, nameUpdate, healthUpdate);

            connection.Close();
        }

        public void DeleteCharacter(int id)
        {
            using SqlConnection connection = new(_connectionString);

            connection.Open();

            string cmdText = @"DELETE
                               FROM PROJ1.Character
                               WHERE mon_id = @id;

                               DECLARE @max int
                               SELECT @max=MAX([mon_id])
                               FROM PROJ1.Character
                               IF @max IS NULL
                                   SET @max = 0
                               DBCC CHECKIDENT ('PROJ1.Character', RESEED, @max);";

            using SqlCommand cmd = new(@cmdText, connection);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            connection.Close();
        }
    }
}
