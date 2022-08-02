using P1API.Model;

namespace P1API.Data
{
    public interface IRepositoryCharacter
    {
        Task<IEnumerable<Character>> GetAllCharactersAsync();
        Task<Character> GetCharacterByIdAsync(int id);
        void AddCharacterRepo(Character character);
        void UpdateCharacterAsync(int id, Character updateCharacter);
        void DeleteCharacter(int id);
    }
}
