using System.ComponentModel.DataAnnotations;

namespace Konyvtar.Dtos
{
    public class KonyvekUpdateDto
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

        [Required]
        public int Max_kolcsonzes { get; set; }

        // Több-több kapcsolat Genre és Author entitásokkal
        [Required]
        public List<int> MufajIdk { get; set; } = new();
        [Required]
        public List<int> SzerzoIdk { get; set; } = new();
        public bool Aktiv { get; set; } = true;
    }
}
