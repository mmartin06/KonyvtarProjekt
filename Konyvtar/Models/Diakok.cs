using System.ComponentModel.DataAnnotations;

namespace Konyvtar.Models
{
    public class Diakok : Alap
    {
        [Key]
        public int Id { get; set; }
        public string Nev { get; set; }
        public string Szul_hely { get; set; }
        public DateTime Szul_ido { get; set; }
        public string Lakcim { get; set; }
        public string Osztaly { get; set; }
        public string Email { get; set; }
    }
}
