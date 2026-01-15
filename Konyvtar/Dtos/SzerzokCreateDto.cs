using System.ComponentModel.DataAnnotations;

namespace Konyvtar.Dtos
{
    public class SzerzokCreateDto
    {
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
    }
}
