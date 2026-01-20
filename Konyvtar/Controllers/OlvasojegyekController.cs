using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Konyvtar.Models;
using Konyvtar.Dtos;

namespace Konyvtar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OlvasojegyekController : ControllerBase
    {
        private readonly KonyvtarContext _context;

        public OlvasojegyekController(KonyvtarContext context)
        {
            _context = context;
        }

        // GET: api/Olvasojegyek
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Olvasojegyek>>> GetOlvasojegyek()
        {
            return await _context.Olvasojegyek.ToListAsync();
        }

        // GET: api/Olvasojegyek/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Olvasojegyek>> GetOlvasojegy(int id)
        {
            var olvasojegyek = await _context.Olvasojegyek.FindAsync(id);

            if (olvasojegyek == null)
            {
                return NotFound();
            }

            return olvasojegyek;
        }

        // PUT: api/Olvasojegyek/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOlvasojegyek(int id, Olvasojegyek olvasojegyek)
        {
            if (id != olvasojegyek.Id)
            {
                return BadRequest();
            }

            _context.Entry(olvasojegyek).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OlvasojegyekExists(id))
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

        // POST: api/Olvasojegyek
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OlvasojegyekDto>> PostOlvasojegyek(OlvasojegyekCreateDto olvasojegyDto)
        {
            var diak = await _context.Diakok.Where(d => d.Aktiv).FirstOrDefaultAsync(d => d.Id == olvasojegyDto.Diak_id);

            var now = DateTime.Now;

            if (diak == null)
            {
                return NotFound("A megadott diák nem található!");
            }

            var olvasojegy = new Olvasojegyek
            {
                Diak_id = olvasojegyDto.Diak_id,
                Kiadas_datum = olvasojegyDto.Kiadas_datum,
                Lejarati_datum = olvasojegyDto.Lejarati_datum,
                Aktiv = true,
                Letrehozva = now,
                Modositva = now,
            };
            _context.Olvasojegyek.Add(olvasojegy);

            _context.SaveChanges();

            var createdOlvasojegyDto = MapToDto(olvasojegy);

            return CreatedAtAction("GetOlvasojegy", new { id = olvasojegy.Id }, createdOlvasojegyDto);
        }

        private OlvasojegyekDto MapToDto(Olvasojegyek olvasojegy)
        {
            return new OlvasojegyekDto
            {
                Id = olvasojegy.Id,
                Diak_id = olvasojegy.Diak_id,
                Kiadas_datum = olvasojegy.Kiadas_datum,
                Lejarati_datum = olvasojegy.Lejarati_datum,
                Aktiv = olvasojegy.Aktiv,
            };
        }

        // DELETE: api/Olvasojegyek/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOlvasojegyek(int id)
        {
            var olvasojegyek = await _context.Olvasojegyek.FindAsync(id);
            if (olvasojegyek == null)
            {
                return NotFound();
            }

            _context.Olvasojegyek.Remove(olvasojegyek);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OlvasojegyekExists(int id)
        {
            return _context.Olvasojegyek.Any(e => e.Id == id);
        }
    }
}
