using Konyvtar.Models;
using System.ComponentModel.DataAnnotations;

namespace Konyvtar.Dtos
{
    public class OlvasojegyekCreateDto
    {
        [Required]
        public int Diak_id { get; set; }
        public Diakok? Diakok { get; set; }
        [Required]
        public DateTime Kiadas_datum { get; set; }
        [Required]
        public DateTime Lejarati_datum { get; set; }
    }
}
