using Microsoft.EntityFrameworkCore;
using P1API.Model;

namespace P1API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Monster> Monsters { get; set; }
    }
}
