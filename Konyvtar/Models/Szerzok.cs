using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Konyvtar.Models
{
    public class Szerzok : Alap
    {
        public ICollection<Konyvek> Konyvek { get; set; } = new List<Konyvek>();

        [InverseProperty("Szerzok")]
        public ICollection<Szerzokonyvek> Szerzokonyvek { get; set; } = new List<Szerzokonyvek>();
        public string Nev { get; set; }
        public DateTime Szul_ido { get; set; }
        public DateTime Szul_hely { get; set; }
        public string Ismerteto { get; set; }
    }
}
