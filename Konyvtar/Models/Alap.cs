using System.ComponentModel.DataAnnotations;

namespace Konyvtar.Models
{
    public class Alap
    {
        [Key]
        public int Id { get; set; }
        public bool Aktiv { get; set; }
        public DateTime Letrehozva { get; set; }
        public DateTime Modositva { get; set; }
    }
}
