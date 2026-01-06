namespace Konyvtar.Dtos
{
    public class KonyvekCreateDto
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
    }
}
