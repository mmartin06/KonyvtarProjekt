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
    public class KonyvekController : ControllerBase
    {
        private readonly KonyvtarContext _context;

        public KonyvekController(KonyvtarContext context)
        {
            _context = context;
        }

        // GET: api/Konyvek
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KonyvekReadDto>>> GetKonyvek()
        {
            var konyvek = await _context.Konyvek
                .Include(b => b.Szerzokonyvek.Where(ba => ba.Aktiv && ba.Szerzok.Aktiv))
                    .ThenInclude(ba => ba.Szerzok)
                .Include(b => b.Mufajkonyvek.Where(bg => bg.Aktiv && bg.Mufajok.Aktiv))
                    .ThenInclude(bg => bg.Mufajok)
                .ToListAsync();

            return konyvek.Select(b => MapToDto(b)).ToList();
        }

        // GET: api/Konyvek/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KonyvekReadDto>> GetKonyv(int id)
        {
            var konyv = await _context.Konyvek
                .Include(b => b.Szerzokonyvek
                    .Where(ba => ba.Aktiv && ba.Szerzok.Aktiv))
                    .ThenInclude(ba => ba.Szerzok)
                .Include(b => b.Mufajkonyvek
                    .Where(bg => bg.Aktiv && bg.Mufajok.Aktiv))
                    .ThenInclude(bg => bg.Mufajok)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (konyv == null)
            {
                return NotFound();
            }

            return MapToDto(konyv);
        }

        // PUT: api/Konyvek/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKonyv(int id, KonyvekUpdateDto konyvDto)
        {
            if (id != konyvDto.Id)
            {
                return BadRequest();
            }

            var now = DateTime.Now;

            var konyv = await _context.Konyvek
                .Include(b => b.Szerzokonyvek)
                .Include(b => b.Mufajkonyvek)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (konyv == null)
            {
                return NotFound();
            }

            // Frissítés
            konyv.Cim_hun = konyvDto.Cim_hun;
            konyv.Cim = konyvDto.Cim;
            konyv.Ajanlo = konyvDto.Ajanlo;
            konyv.Kiadas_eve = konyvDto.Kiadas_eve;
            konyv.Peldanyszam = konyvDto.Peldanyszam;
            konyv.Kiado = konyvDto.Kiado;
            konyv.Max_kolcsonzes = konyvDto.Max_kolcsonzes;
            konyv.Modositva = now;
            konyv.Aktiv = konyvDto.Aktiv;

            // Szerzők és műfajok frissítése
            // Műfajok

            if (konyvDto.MufajIdk != null && konyvDto.MufajIdk.Count > 0)
            {

                var letezoMufajIdk = konyv.Mufajkonyvek
                    .Where(bg => bg.Aktiv)
                    .Select(bg => bg.Mufaj_id)
                    .ToList();

                var ujValidMufajIdk = await _context.Mufajok
                    .Where(g => konyvDto.MufajIdk.Contains(g.Id) && g.Aktiv)
                    .Select(g => g.Id)
                    .ToListAsync();

                if (ujValidMufajIdk == null || ujValidMufajIdk.Count == 0)
                {
                    return BadRequest("Nem lett érvényes műfaj megadva!");
                }

                // Új műfajok hozzáadása

                foreach (var gid in ujValidMufajIdk)
                {
                    var letezoRelation = konyv.Mufajkonyvek
                                            .FirstOrDefault(bg => bg.Mufaj_id == gid);

                    if (letezoRelation == null)
                    {
                        konyv.Mufajkonyvek.Add(
                            new Mufajkonyvek
                        {
                            Konyv_id = konyv.Id,
                            Mufaj_id = gid,
                            Letrehozva = now,
                            Modositva = now,
                            Aktiv = true
                        });
                    }
                    else if (!letezoRelation.Aktiv)
                    {
                        // Ha korábban inaktív volt, akkor újraaktiváljuk
                        letezoRelation.Aktiv = true;
                        letezoRelation.Modositva = now;
                    }
                }

                // Műfajok törlése (IsActive=false)

                foreach (var gid in letezoMufajIdk)
                {
                    if (!konyvDto.MufajIdk.Contains(gid))
                    {
                        var konyvMufaj = konyv.Mufajkonyvek.FirstOrDefault(bg => bg.Mufaj_id == gid);

                        if (konyvMufaj != null)
                        {
                            konyvMufaj.Aktiv = false;
                            konyvMufaj.Modositva = now;
                        }
                    }
                }
            }

            // Szerzők kezelése

            if (konyvDto.SzerzoIdk != null && konyvDto.SzerzoIdk.Count > 0)
            {
                var letezoSzerzoIdk = konyv.Szerzokonyvek
                    .Where(ba => ba.Aktiv)
                    .Select(ba => ba.Szerzo_id)
                    .ToList();

                var ujValidSzerzoIdk = await _context.Szerzok
                    .Where(a => konyvDto.SzerzoIdk.Contains(a.Id) && a.Aktiv)
                    .Select(a => a.Id)
                    .ToListAsync();

                if (ujValidSzerzoIdk == null || ujValidSzerzoIdk.Count == 0)
                {
                    return BadRequest("Nem lett érvényes szerző megadva!");
                }
                // Új szerző hozzáadása

                foreach (var aid in ujValidSzerzoIdk)
                {
                    var letezoRelation = konyv.Szerzokonyvek
                                            .FirstOrDefault(ba => ba.Szerzo_id == aid);

                    if (letezoRelation == null)
                    {
                        konyv.Szerzokonyvek.Add(
                            new Szerzokonyvek
                        {
                            Konyv_id = konyv.Id,
                            Szerzo_id = aid,
                            Letrehozva = now,
                            Modositva = now,
                            Aktiv = true
                        });

                    }
                    else if (!letezoRelation.Aktiv)
                    {
                        // Ha korábban inaktív volt, akkor újraaktiváljuk
                        letezoRelation.Aktiv = true;
                        letezoRelation.Modositva = now;
                    }
                }

                // Szerző törlése (IsActive=false)

                foreach (var aid in letezoSzerzoIdk)
                {
                    if (!konyvDto.SzerzoIdk.Contains(aid))
                    {
                        var konyvSzerzo = konyv.Szerzokonyvek.FirstOrDefault(ba => ba.Szerzo_id == aid);

                        if (konyvSzerzo != null)
                        {
                            konyvSzerzo.Aktiv = false;
                            konyvSzerzo.Modositva = now;
                        }
                    }
                }
            }
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KonyvExists(id))
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
        public async Task<ActionResult<KonyvekReadDto>> PostKonyv(KonyvekCreateDto konyvDto)
        {
            // Elérhető példányok kezdeti értéke megegyezik a teljes példányszámmal

            var now = DateTime.Now;

            var konyv = new Konyvek
            {
                Cim_hun = konyvDto.Cim_hun,
                Cim = konyvDto.Cim,
                Ajanlo = konyvDto.Ajanlo,
                Kiadas_eve = konyvDto.Kiadas_eve,
                Peldanyszam = konyvDto.Peldanyszam,
                Szpeldany = konyvDto.Szpeldany,
                Kiado = konyvDto.Kiado,
                Max_kolcsonzes = konyvDto.Max_kolcsonzes,
                Letrehozva = now,
                Modositva = now,
                Aktiv = true
            };

            // Szerző és műfaj kapcsolatok létrehozása

            // Műfajok hozzáadása

            if (konyvDto.MufajIdk != null && konyvDto.MufajIdk.Count > 0)
            {
                var mufajok = await _context.Mufajok
                        .Where(g => konyvDto.MufajIdk.Contains(g.Id) && g.Aktiv)
                        .ToListAsync();

                if (mufajok == null || mufajok.Count == 0)
                {
                    return BadRequest("Nem lett érvényes műfaj megadva!");
                }
                foreach (var mufaj in mufajok)
                {
                    konyv.Mufajkonyvek.Add(
                        new Mufajkonyvek
                        {
                            Mufajok = mufaj,
                            Letrehozva = now,
                            Modositva = now,
                            Aktiv = true
                        }
                     );
                }
            }

            // Szerzők hozzáadása

            if (konyvDto.SzerzoIdk != null && konyvDto.SzerzoIdk.Count > 0)
            {
                var szerzok = await _context.Szerzok
                        .Where(a => konyvDto.SzerzoIdk.Contains(a.Id) && a.Aktiv)
                        .ToListAsync();

                if (szerzok == null || szerzok.Count == 0)
                {
                    return BadRequest("Nem lett érvényes szerző megadva!");
                }

                foreach (var szerzo in szerzok)
                {
                    konyv.Szerzokonyvek.Add(
                        new Szerzokonyvek
                        {
                            Szerzok = szerzo,
                            Letrehozva = now,
                            Modositva = now,
                            Aktiv = true
                        }
                     );
                }
            }
            _context.Konyvek.Add(konyv);

            await _context.SaveChangesAsync();

            var letrehozottKonyvDto = MapToDto(konyv);

            return CreatedAtAction("GetKonyv", new { id = konyv.Id }, letrehozottKonyvDto);
        }

        /*
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
        */

        private bool KonyvExists(int id)
        {
            return _context.Konyvek.Any(e => e.Id == id);
        }

        private KonyvekReadDto MapToDto(Konyvek konyv)
        {
            return new KonyvekReadDto
            {
                Id = konyv.Id,
                Cim_hun = konyv.Cim_hun,
                Cim = konyv.Cim,
                Ajanlo = konyv.Ajanlo,
                Kiadas_eve = konyv.Kiadas_eve,
                Peldanyszam = konyv.Peldanyszam,
                Szpeldany = konyv.Szpeldany,
                Kiado = konyv.Kiado,
                Max_kolcsonzes = konyv.Max_kolcsonzes,
                Mufajok = konyv.Mufajkonyvek.Select(bg => new MufajokForTopDto
                {
                    Id = bg.Mufajok.Id,
                    Mufaj = bg.Mufajok.Mufaj
                }).ToList(),
                Szerzok = konyv.Szerzokonyvek.Select(ba => new SzerzokForTopDto
                {
                    Id = ba.Szerzok.Id,
                    Nev = ba.Szerzok.Nev
                }).ToList(),
                Aktiv = konyv.Aktiv,
                Letrehozva = konyv.Letrehozva,
                Modositva = konyv.Modositva
            };
        }
    }
}
