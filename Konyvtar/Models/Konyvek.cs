using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Konyvtar.Models
{
    public class Konyvek : Alap
    {
        public string Cim_hun { get; set; }
        public string Cim { get; set; }
        public string Ajanlo { get; set; }
        public int Kiadas_eve { get; set; }
        public int Peldanyszam { get; set; }
        public int Szpeldany { get; set; }
        public string Kiado { get; set; }
        public string Mufaj { get; set; }
        public string Szerzo { get; set; }
        public int Max_kolcsonzes { get; set; }
        public ICollection<Kolcsonzesek> Kolcsonzesek { get; set; } = new List<Kolcsonzesek>();
        public ICollection<Mufajok> Mufajok { get; set; } = new List<Mufajok>();

        [InverseProperty("Konyvek")]
        public ICollection<Mufajkonyvek> Mufajkonyvek { get; set; } = new List<Mufajkonyvek>();
        public ICollection<Szerzok> Szerzok { get; set; } = new List<Szerzok>();

        [InverseProperty("Konyvek")]
        public ICollection<Szerzokonyvek> Szerzokonyvek { get; set; } = new List<Szerzokonyvek>();
    }
}
