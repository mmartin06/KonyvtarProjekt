using Konyvtar.Models;

namespace Konyvtar.Dtos
{
    public class DiakokDto 
    {
        public int Id { get; set; }
        public string Nev { get; set; }
        public string Szul_hely { get; set; }
        public DateTime Szul_ido { get; set; }
        public string Lakcim { get; set; }
        public string Osztaly { get; set; }
        public string Email { get; set; }
        public bool Aktiv { get; set; }
    }
}
