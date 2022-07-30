using P1API.Model;

namespace P1API.Data
{
    public interface IRepository
    {
        Task<IEnumerable<Monster>> GetAllMonstersAsync();
    }
}