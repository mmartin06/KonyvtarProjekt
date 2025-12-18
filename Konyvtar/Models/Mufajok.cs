using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Konyvtar.Models
{
    public class Mufajok : Alap
    {
        public ICollection<Konyvek> Konyvek { get; set; } = new List<Konyvek>();

        [InverseProperty("Mufajok")]
        public ICollection<Mufajkonyvek> Mufajkonyvek { get; set; } = new List<Mufajkonyvek>();
        public string Mufaj { get; set; }
    }
}
