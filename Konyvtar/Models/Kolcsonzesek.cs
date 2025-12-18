using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Konyvtar.Models
{
    public class Kolcsonzesek : Alap
    {
        public int Diak_id { get; set; }
        [ForeignKey("Diak_id")]
        public Diakok? Diakok { get; set; }
        public int Konyv_id { get; set; }
        [ForeignKey("Konyv_id")]
        public Konyvek? Konyvek { get; set; }
        public DateTime Kolcsonzes_datum { get; set; }
        public DateTime Visszahozatal_hatarido { get; set; }
        public DateTime Visszahozatal_datum { get; set; }
    }
}
