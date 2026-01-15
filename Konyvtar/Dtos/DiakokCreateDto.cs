using System.ComponentModel.DataAnnotations;

namespace Konyvtar.Dtos
{
    public class DiakokCreateDto
    {
        [Required]
        [MaxLength(50)]
        public string Nev { get; set; }
        [Required]
        [MaxLength(50)]
        public string Szul_hely { get; set; }
        [Required]
        public DateTime Szul_ido { get; set; }
        [Required]
        [MaxLength(100)]
        public string Lakcim { get; set; }
        [Required]
        [MaxLength(5)]
        public string Osztaly { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
