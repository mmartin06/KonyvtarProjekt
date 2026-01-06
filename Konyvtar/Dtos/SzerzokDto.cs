using Konyvtar.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Konyvtar.Dtos
{
    public class SzerzokDto
    {
        public int Id { get; set; }
        public string Nev { get; set; }
        public DateTime Szul_ido { get; set; }
        public DateTime Szul_hely { get; set; }
        public string Ismerteto { get; set; }
        public bool Aktiv {  get; set; }
    }
}
