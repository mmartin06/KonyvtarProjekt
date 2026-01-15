using Konyvtar.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Konyvtar.Dtos
{
    public class KolcsonzesekDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int Diak_id { get; set; }
        public Diakok? Diakok { get; set; }
        [Required]
        public int Konyv_id { get; set; }
        public Konyvek? Konyvek { get; set; }
        [Required]
        public DateTime Kolcsonzes_datum { get; set; }
        [Required]
        public DateTime Visszahozatal_hatarido { get; set; }
        public DateTime Visszahozatal_datum { get; set; }
        public bool Aktiv { get; set; }
    }
}
