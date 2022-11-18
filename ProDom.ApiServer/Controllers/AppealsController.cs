﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProDom.ApiServer.Models;

namespace ProDom.ApiServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppealsController : ControllerBase
    {
        private readonly ApiContext _context;

        public AppealsController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/Appeals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Appeal>>> GetAppeal()
        {
            return await _context.Appeals.ToListAsync();
        }

        // GET: api/Appeals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Appeal>> GetAppeal(int id)
        {
            var appeal = await _context.Appeals.FindAsync(id);

            if (appeal == null)
            {
                return NotFound();
            }

            return appeal;
        }

        // PUT: api/Appeals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppeal(int id, Appeal appeal)
        {
            if (id != appeal.Id)
            {
                return BadRequest();
            }

            _context.Entry(appeal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppealExists(id))
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

        // POST: api/Appeals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Appeal>> PostAppeal(Appeal appeal)
        {
            _context.Appeals.Add(appeal);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAppeal", new { id = appeal.Id }, appeal);
        }

        // DELETE: api/Appeals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppeal(int id)
        {
            var appeal = await _context.Appeals.FindAsync(id);
            if (appeal == null)
            {
                return NotFound();
            }

            _context.Appeals.Remove(appeal);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AppealExists(int id)
        {
            return _context.Appeals.Any(e => e.Id == id);
        }
    }
}
