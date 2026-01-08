namespace Konyvtar.Dtos
{
    public class AktualisKeszletKonyvekStatDto
    {
        public int Id { get; set; }
        public string Cim_hun { get; set; }
        public string Cim { get; set; }
        List<SzerzokForTopDto> Szerzok { get; set; }
        List<MufajokForTopDto> Mufajok { get; set; }
    }
}
