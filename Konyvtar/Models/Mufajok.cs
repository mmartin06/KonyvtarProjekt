using System.ComponentModel.DataAnnotations;

namespace Konyvtar.Models
{
    public class Mufajok : Alap
    {
        [Key]
        public int Id { get; set; }
        public string Mufaj { get; set; }
    }
}
