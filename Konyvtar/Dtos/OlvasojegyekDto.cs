using Konyvtar.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Konyvtar.Dtos
{
    public class OlvasojegyekDto
    {
        public int Id { get; set; }
        public int Diak_id { get; set; }
        public Diakok? Diakok { get; set; }
        public DateTime Kiadas_datum { get; set; }
        public DateTime Lejarati_datum { get; set; }
        public bool Aktiv { get; set; }
    }
}
