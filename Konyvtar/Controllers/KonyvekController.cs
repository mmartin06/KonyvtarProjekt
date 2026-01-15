using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Konyvtar.Models;

namespace Konyvtar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KonyvekController : ControllerBase
    {
        private readonly KonyvtarContext _context;

        public KonyvekController(KonyvtarContext context)
        {
            _context = context;
        }

        // GET: api/Konyvek
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Konyvek>>> GetKonyvek()
        {
            return await _context.Konyvek.ToListAsync();
        }

        // GET: api/Konyvek/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Konyvek>> GetKonyvek(int id)
        {
            var konyvek = await _context.Konyvek.FindAsync(id);

            if (konyvek == null)
            {
                return NotFound();
            }

            return konyvek;
        }

        // PUT: api/Konyvek/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKonyvek(int id, Konyvek konyvek)
        {
            if (id != konyvek.Id)
            {
                return BadRequest();
            }

            _context.Entry(konyvek).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KonyvekExists(id))
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

        // POST: api/Konyvek
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Konyvek>> PostKonyvek(Konyvek konyvek)
        {
            _context.Konyvek.Add(konyvek);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKonyvek", new { id = konyvek.Id }, konyvek);
        }

        // DELETE: api/Konyvek/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKonyvek(int id)
        {
            var konyvek = await _context.Konyvek.FindAsync(id);
            if (konyvek == null)
            {
                return NotFound();
            }

            _context.Konyvek.Remove(konyvek);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KonyvekExists(int id)
        {
            return _context.Konyvek.Any(e => e.Id == id);
        }
    }
}
