namespace Konyvtar.Dtos
{
    public class KonyvekTopStatDto
    {
        public int Id { get; set; }
        public string Cim_hun { get; set; }
        public string Cim { get; set; }
        List<SzerzokForTopDto> Szerzok {  get; set; }
        List<MufajokForTopDto> Mufajok { get; set;}
        public int KikolcsonzesSzam {  get; set; }
    }
}
