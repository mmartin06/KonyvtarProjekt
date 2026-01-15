using Konyvtar.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Konyvtar.Dtos
{
    public class OlvasojegyekDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int Diak_id { get; set; }
        public Diakok? Diakok { get; set; }
        [Required]
        public DateTime Kiadas_datum { get; set; }
        [Required]
        public DateTime Lejarati_datum { get; set; }
        public bool Aktiv { get; set; }
    }
}
