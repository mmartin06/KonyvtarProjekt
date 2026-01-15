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
    public class MufajokController : ControllerBase
    {
        private readonly KonyvtarContext _context;

        public MufajokController(KonyvtarContext context)
        {
            _context = context;
        }

        // GET: api/Mufajok
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MufajokDto>>> GetMufajok()
        {
            var mufajok = await _context.Mufajok.ToListAsync();

            return mufajok.Select(a => MapToDto(a)).ToList();
        }

        // GET: api/Mufajok/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MufajokDto>> GetMufaj(int id)
        {
            var mufaj = await _context.Mufajok.FindAsync(id);

            if (mufaj == null)
            {
                return NotFound();
            }

            return MapToDto(mufaj);
        }

        // PUT: api/Mufajok/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMufajok(int id, MufajokDto mufajokDto)
        {
            if (id != mufajokDto.Id)
            {
                return BadRequest();
            }

            var mufaj = _context.Mufajok.Find(id);

            if (mufaj == null)
            {
                return NotFound();
            }

            mufaj.Mufaj = mufajokDto.Mufaj;
            mufaj.Aktiv = mufajokDto.Aktiv;
            mufaj.Modositva = DateTime.Now;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MufajokExists(id))
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

        // POST: api/Mufajok
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MufajokDto>> PostMufajok(MufajokCreateDto mufajDto)
        {
            var now = DateTime.Now;

            var mufaj = new Mufajok
            {
                Mufaj = mufajDto.Mufaj,
                Aktiv = true,
                Letrehozva = now,
                Modositva = now
            };

            _context.Mufajok.Add(mufaj);
            await _context.SaveChangesAsync();

            var createdMufajDto = MapToDto(mufaj);

            return CreatedAtAction("GetMufaj", new { id = mufaj.Id }, createdMufajDto);
        }

        /*
        // DELETE: api/Mufajok/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMufajok(int id)
        {
            var mufajok = await _context.Mufajok.FindAsync(id);
            if (mufajok == null)
            {
                return NotFound();
            }

            _context.Mufajok.Remove(mufajok);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        */

        private bool MufajokExists(int id)
        {
            return _context.Mufajok.Any(e => e.Id == id);
        }
        private MufajokDto MapToDto(Mufajok mufaj)
        {
            return new MufajokDto
            {
                Id = mufaj.Id,
                Mufaj = mufaj.Mufaj,
                Aktiv = mufaj.Aktiv
            };
        }
    }
}
