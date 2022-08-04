using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P1API.Data;
using P1API.Model;
using System.Text;
using System.Text.Json;

namespace P1API.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonsterController : ControllerBase
    {
        // Fields
        private readonly IRepositoryMonster _repo;
        private readonly ILogger<MonsterController> _logger;

        // Constructor
        public MonsterController(IRepositoryMonster repo, ILogger<MonsterController> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        // Methods

        // GET /api/monsters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Monster>>> GetAllMonsters()
        {
            IEnumerable<Monster> monsters;

            try
            {
                monsters = await _repo.GetAllMonstersAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(500);
            }

            return Ok(monsters.ToList());
        }

        [HttpGet("{id}")]
        public async Task<Monster> GetMonsterById(int id)
        {
            Monster monster = await _repo.GetMonsterByIdAsync(id);
            return monster;
        }

        // [FromBody] automatically deserializes under the hood
        [HttpPost]
        public void AddMonster([FromBody] Monster newMonster)
        {
            _repo.AddMonsterRepo(newMonster);
        }

        [HttpPut("{id}")]
        public void UpdateMonster(int id,[FromBody] Monster updateMonster)
        {
            _repo.UpdateMonsterAsync(id, updateMonster);
        }

        [HttpDelete("{id}")]
        public void DeleteMonster(int id)
        {
            _repo.DeleteMonster(id);
        }
    }
}
