using Konyvtar.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Konyvtar.Dtos
{
    public class KonyvekReadDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string Cim_hun { get; set; }
        [Required]
        public string Cim { get; set; }
        [Required]
        [MinLength(30)]
        public string Ajanlo { get; set; }
        [Required]
        [MaxLength(200)]
        public int Kiadas_eve { get; set; }
        [Required]
        public int Peldanyszam { get; set; }
        [Required]
        public int Szpeldany { get; set; }
        [Required]
        public string Kiado { get; set; }

        /*[Required]
        public string Mufaj { get; set; }
        public string Szerzo { get; set; }*/

        public List<MufajokForTopDto> Mufajok { get; set; } = new();
        public List<SzerzokForTopDto> Szerzok { get; set; } = new();

        [Required]
        public int Max_kolcsonzes { get; set; }
        public bool Aktiv { get; set; }
        public DateTime Letrehozva { get; set; }
        public DateTime Modositva { get; set; }
    }
}
