using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using duonghongluyen.Exercise02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using duonghongluyen.Exercise02.Context;
namespace duonghongluyen.Exercise02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardItemsController : ControllerBase
    {
        private readonly Exercise02Context _context;

        public CardItemsController(Exercise02Context context)
        {
            _context = context;
        }

        // GET: api/CardItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CardItem>>> GetCardItems()
        {
            return await _context.CardItems.Include(ci => ci.Product).ToListAsync();
        }

        // GET: api/CardItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CardItem>> GetCardItem(Guid id)
        {
            var cardItem = await _context.CardItems.Include(ci => ci.Product).FirstOrDefaultAsync(ci => ci.Id == id);

            if (cardItem == null)
            {
                return NotFound();
            }

            return cardItem;
        }

        // POST: api/CardItems
        [HttpPost]
        public async Task<ActionResult<CardItem>> PostCardItem(CardItem cardItem)
        {
            _context.CardItems.Add(cardItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCardItem), new { id = cardItem.Id }, cardItem);
        }

        // DELETE: api/CardItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCardItem(Guid id)
        {
            var cardItem = await _context.CardItems.FindAsync(id);
            if (cardItem == null)
            {
                return NotFound();
            }

            _context.CardItems.Remove(cardItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CardItemExists(Guid id)
        {
            return _context.CardItems.Any(e => e.Id == id);
        }
    }
}
