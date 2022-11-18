using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProDom.ApiServer.Models;

namespace ProDom.ApiServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PollsController : ControllerBase
    {
        private readonly ApiContext _context;

        public PollsController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/Polls
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Poll>>> GetPoll()
        {
            return await _context.Polls.ToListAsync();
        }

        // GET: api/Polls/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Poll>> GetPoll(int id)
        {
            var poll = await _context.Polls.FindAsync(id);

            if (poll == null)
            {
                return NotFound();
            }

            return poll;
        }

        // PUT: api/Polls/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPoll(int id, Poll poll)
        {
            if (id != poll.Id)
            {
                return BadRequest();
            }

            _context.Entry(poll).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PollExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Polls
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Poll>> PostPoll(Poll poll)
        {
            _context.Polls.Add(poll);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPoll", new { id = poll.Id }, poll);
        }

        // DELETE: api/Polls/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePoll(int id)
        {
            var poll = await _context.Polls.FindAsync(id);
            if (poll == null)
            {
                return NotFound();
            }

            _context.Polls.Remove(poll);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PollExists(int id)
        {
            return _context.Polls.Any(e => e.Id == id);
        }
    }
}
