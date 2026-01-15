using Konyvtar.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Konyvtar.Dtos
{
    public class SzerzokDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Nev { get; set; }
        [Required]
        public DateTime Szul_ido { get; set; }
        [Required]
        [MaxLength(100)]
        public DateTime Szul_hely { get; set; }
        [MaxLength(500)]
        public string Ismerteto { get; set; }
        public bool Aktiv {  get; set; }
    }
}
