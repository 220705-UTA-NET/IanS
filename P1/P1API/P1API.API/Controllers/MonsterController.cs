using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P1API.Data;
using P1API.Model;

namespace P1API.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonsterController : ControllerBase
    {
        // Fields
        private readonly IRepository _repo;
        private readonly ILogger<MonsterController> _logger;

        // Constructor
        public MonsterController(IRepository repo, ILogger<MonsterController> logger)
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

            return monsters.ToList();
        }
    }
}
