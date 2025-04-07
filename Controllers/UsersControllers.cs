using Microsoft.AspNetCore.Mvc;
using testingMongoLocal.Models;
using testingMongoLocal.Repositories;


namespace testingMongoLocal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UserRepository _repo;

        public UsersController(UserRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> Get() =>
            await _repo.GetAllAsync();

        [HttpPost]
        public async Task<IActionResult> Post(User user)
        {
            await _repo.AddAsync(user);
            return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
        }
    }
}