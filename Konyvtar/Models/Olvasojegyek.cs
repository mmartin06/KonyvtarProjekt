using System.ComponentModel.DataAnnotations;

namespace Konyvtar.Models
{
    public class Olvasojegyek : Alap
    {
        [Key]
        public int Id { get; set; }
        public int Diak_id { get; set; }
        public DateTime Kiadas_datum { get; set; }
        public DateTime Lejarati_datum { get; set; }
    }
}
