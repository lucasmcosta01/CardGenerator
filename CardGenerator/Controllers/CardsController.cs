using CardGenerator.Models;
using CardGenerator.Models.Domains;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CardGenerator.Controllers
{
    [ApiController]
    [Route("api/cards")]
    public class CardsController : Controller
    {
        private readonly ApiContext _context;

        public CardsController(ApiContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Card card)
        {
            _context.Cards.Add(card);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Read), new { id = card.Id}, card);
        }

        [HttpGet]
        public async Task<IActionResult> Read(int id)
        {
            Card card = await _context.Cards.FindAsync(id);
            return card == null ? NotFound() : Ok(card);
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return Ok(_context.Cards.OrderBy(c => EF.Property<object>(c, "Id")));
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, [FromBody] Card card) 
        {
            Card newCard = await _context.Cards.FindAsync(id);
            newCard.Number = card.Number;
            await _context.SaveChangesAsync();
            return newCard == null ? NotFound() : Ok(newCard);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            Card newCard = await _context.Cards.FindAsync(id);
            _context.Cards.Remove(newCard);
            return Ok( await _context.SaveChangesAsync());
        }
    }
}
