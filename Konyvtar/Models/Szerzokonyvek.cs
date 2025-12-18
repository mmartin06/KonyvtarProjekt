using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Konyvtar.Models
{
    public class Szerzokonyvek : Alap
    {
        public int Szerzo_id { get; set; }
        [ForeignKey("Szerzo_id")]
        public Szerzok? Szerzok {  get; set; }
        public int Konyv_id { get; set; }
        [ForeignKey("Konyv_id")]
        public Konyvek? Konyvek { get; set; }
    }
}
