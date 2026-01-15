using System.ComponentModel.DataAnnotations;

namespace Konyvtar.Dtos
{
    public class MufajokDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Mufaj { get; set; }
        public bool Aktiv {  get; set; }
    }
}
