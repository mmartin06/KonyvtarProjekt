using Konyvtar.Models;

namespace Konyvtar.Dtos
{
    public class KolcsonzesekCreateDto
    {
        public int Diak_id { get; set; }
        public Diakok? Diakok { get; set; }
        public int Konyv_id { get; set; }
        public Konyvek? Konyvek { get; set; }
        public DateTime Kolcsonzes_datum { get; set; }
        public DateTime Visszahozatal_hatarido { get; set; }
        public DateTime Visszahozatal_datum { get; set; }
    }
}
