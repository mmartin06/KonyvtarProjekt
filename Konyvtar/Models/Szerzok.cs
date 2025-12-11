using System.ComponentModel.DataAnnotations;

namespace Konyvtar.Models
{
    public class Szerzok : Alap
    {
        [Key]
        public int Id { get; set; }
        public string Nev { get; set; }
        public DateTime Szul_ido { get; set; }
        public DateTime Szul_hely { get; set; }
        public string Ismerteto { get; set; }
    }
}
