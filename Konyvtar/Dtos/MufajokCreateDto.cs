using System.ComponentModel.DataAnnotations;

namespace Konyvtar.Dtos
{
    public class MufajokCreateDto
    {
        [Required]
        [MaxLength(50)]
        public string Mufaj { get; set; }
    }
}
