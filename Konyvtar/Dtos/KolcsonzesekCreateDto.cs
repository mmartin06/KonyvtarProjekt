using Konyvtar.Models;
using System.ComponentModel.DataAnnotations;

namespace Konyvtar.Dtos
{
    public class KolcsonzesekCreateDto
    {
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
    }
}
