using System.ComponentModel.DataAnnotations;

namespace Konyvtar.Models
{
    public class Kolcsonzesek : Alap
    {
        [Key]
        public int Id { get; set; }
        public int Diak_id { get; set; }
        public int Konyv_id { get; set; }
        public DateTime Kolcsonzes_datum { get; set; }
        public DateTime Visszahozatal_hatarido { get; set; }
        public DateTime Visszahozatal_datum { get; set; }
    }
}
