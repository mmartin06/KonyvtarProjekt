namespace Konyvtar.Dtos
{
    public class SzerzoSzerintKonyvekStatDto
    {
        List<SzerzokForTopDto> Szerzok { get; set; }
        public int Id { get; set; }
        public string Cim_hun { get; set; }
        public string Cim { get; set; }
        List<MufajokForTopDto> Mufajok { get; set; }
        public int Peldanyszam { get; set; }
        public int Szpeldany { get; set; }
        public int Kiadas_eve { get; set; }
    }
}
