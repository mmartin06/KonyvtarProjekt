using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Konyvtar.Models
{
    public class Mufajkonyvek : Alap
    {
        public int Mufaj_id { get; set; }
        [ForeignKey("Mufaj_id")]
        public Mufajok? Mufajok { get; set; }
        public int Konyv_id { get; set; }
        [ForeignKey("Konyv_id")]
        public Konyvek? Konyvek { get; set; }
    }
}
