using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Konyvtar.Dtos;
using Konyvtar.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SzerzokController : ControllerBase
    {
        private readonly KonyvtarContext _context;

        public SzerzokController(KonyvtarContext context)
        {
            _context = context;
        }

        // GET: api/Authors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SzerzokDto>>> GetSzerzok()
        {
            var szerzok = await _context.Szerzok.ToListAsync();

            return szerzok.Select(a => MapToDto(a)).ToList();
        }

        // GET: api/Authors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SzerzokDto>> GetSzerzo(int id)
        {
            var szerzo = await _context.Szerzok.FindAsync(id);

            if (szerzo == null)
            {
                return NotFound();
            }

            return MapToDto(szerzo);
        }

        // PUT: api/Authors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSzerzo(int id, SzerzokDto authorDto)
        {
            if (id != authorDto.Id)
            {
                return BadRequest();
            }

            var szerzo = _context.Szerzok.Find(id);

            if (szerzo == null)
            {
                return NotFound();
            }

            szerzo.Nev = authorDto.Nev;
            szerzo.Szul_ido = authorDto.Szul_ido;
            szerzo.Szul_hely = authorDto.Szul_hely;
            szerzo.Ismerteto = authorDto.Ismerteto;
            szerzo.Aktiv = authorDto.Aktiv;
            szerzo.Modositva = DateTime.Now;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SzerzoExists(id))
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

        // POST: api/Authors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SzerzokDto>> PostSzerzo(SzerzokCreateDto szerzoDto)
        {
            var now = DateTime.Now;

            var szerzo = new Szerzok
            {
                Nev = szerzoDto.Nev,
                Szul_ido = szerzoDto.Szul_ido,
                Szul_hely = szerzoDto.Szul_hely,
                Ismerteto = szerzoDto.Ismerteto,
                Aktiv = true,
                Letrehozva = DateTime.Now,
                Modositva = DateTime.Now,
            };

            _context.Szerzok.Add(szerzo);
            await _context.SaveChangesAsync();

            var createdSzerzoDto = MapToDto(szerzo);

            return CreatedAtAction("GetSzerzo", new { id = szerzo.Id }, createdSzerzoDto);
        }

        /* Nincs törlés, csak IsActive állítás
         
        // DELETE: api/Authors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author == null)
            {
                return NotFound();
            }

            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        */

        private bool SzerzoExists(int id)
        {
            return _context.Szerzok.Any(e => e.Id == id);
        }

        private SzerzokDto MapToDto(Szerzok szerzo)
        {
            return new SzerzokDto
            {
                Id = szerzo.Id,
                Nev = szerzo.Nev,
                Szul_ido = szerzo.Szul_ido,
                Szul_hely = szerzo.Szul_hely,
                Ismerteto = szerzo.Ismerteto,
                Aktiv = szerzo.Aktiv,
            };
        }
    }
}
