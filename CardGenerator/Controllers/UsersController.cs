using CardGenerator.Models;
using CardGenerator.Models.Domains;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CardGenerator.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : Controller
    {
        private readonly ApiContext _context;

        public UsersController(ApiContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Read), new { id = user.Id }, user);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Read(int id)
        {
            var user = await _context.Users.FindAsync(id);
            return user == null ? NotFound() : Ok(user);
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, [FromBody] User user)
        {
            User newUser = await _context.Users.FindAsync(id);
            newUser.Email = user.Email;
            newUser.Cards = user.Cards;
            await _context.SaveChangesAsync();
            return newUser == null ? NotFound() : Ok(newUser);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            User newUser = await _context.Users.FindAsync(id);
            _context.Users.Remove(newUser);
            return Ok(await _context.SaveChangesAsync());
        }
    }
}
