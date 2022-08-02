using P1API.Model;

namespace P1API.Data
{
    public interface IRepositoryMonster
    {
        Task<IEnumerable<Monster>> GetAllMonstersAsync();
        Task<Monster> GetMonsterByIdAsync(int id);
        void AddMonsterRepo(Monster monster);
        void UpdateMonsterAsync(int id, Monster updateMonster);
        void DeleteMonster(int id);
    }
}