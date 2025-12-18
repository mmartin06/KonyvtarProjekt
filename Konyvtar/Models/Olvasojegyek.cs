using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Konyvtar.Models
{
    public class Olvasojegyek : Alap
    {
        public int Diak_id { get; set; }
        [ForeignKey("Diak_id")]
        public Diakok? Diakok { get; set; }
        public DateTime Kiadas_datum { get; set; }
        public DateTime Lejarati_datum { get; set; }
    }
}
