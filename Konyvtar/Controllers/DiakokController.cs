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
    public class DiakokController : ControllerBase
    {
        private readonly KonyvtarContext _context;

        public DiakokController(KonyvtarContext context)
        {
            _context = context;
        }

        // GET: api/Diakok
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DiakokDto>>> GetDiakok()
        {
            var diakok = await _context.Diakok.ToListAsync();

            return diakok.Select(a => MapToDto(a)).ToList();
        }

        // GET: api/Diakok/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DiakokDto>> GetDiak(int id)
        {
            var diak = await _context.Diakok.FindAsync(id);

            if (diak == null)
            {
                return NotFound();
            }

            return MapToDto(diak);
        }

        // PUT: api/Diakok/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDiak(int id, DiakokDto diakDto)
        {
            if (id != diakDto.Id)
            {
                return BadRequest();
            }

            var diak = _context.Diakok.Find(id);

            if (diak == null)
            {
                return NotFound();
            }

            diak.Nev = diakDto.Nev;
            diak.Szul_hely = diakDto.Szul_hely;
            diak.Szul_ido = diakDto.Szul_ido;
            diak.Lakcim = diakDto.Lakcim;
            diak.Osztaly = diakDto.Osztaly;
            diak.Email = diakDto.Email;
            diak.Aktiv = diakDto.Aktiv;
            diak.Modositva = DateTime.Now;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiakExists(id))
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

        // POST: api/Diakok
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DiakokDto>> PostDiakok(DiakokCreateDto diakDto)
        {
            var now = DateTime.Now;

            var diak = new Diakok
            {
                Nev = diakDto.Nev,
                Szul_hely = diakDto.Szul_hely,
                Szul_ido = diakDto.Szul_ido,
                Lakcim = diakDto.Lakcim,
                Osztaly = diakDto.Osztaly,
                Email = diakDto.Email,
                Aktiv = true,
                Letrehozva = now,
                Modositva = now
            };
            _context.Diakok.Add(diak);
            await _context.SaveChangesAsync();

            var createdDiakDto = MapToDto(diak);

            return CreatedAtAction("GetDiak", new { id = diak.Id }, createdDiakDto);
        }

        /*

        // DELETE: api/Diakok/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiakok(int id)
        {
            var diakok = await _context.Diakok.FindAsync(id);
            if (diakok == null)
            {
                return NotFound();
            }

            _context.Diakok.Remove(diakok);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        */
        private bool DiakExists(int id)
        {
            return _context.Diakok.Any(e => e.Id == id);
        }

        private DiakokDto MapToDto(Diakok diak)
        {
            return new DiakokDto
            {
                Id = diak.Id,
                Nev = diak.Nev,
                Szul_hely = diak.Szul_hely,
                Szul_ido = diak.Szul_ido,
                Lakcim = diak.Lakcim,
                Osztaly = diak.Osztaly,
                Email = diak.Email,
                Aktiv = diak.Aktiv,
            };
        }
    }
}
