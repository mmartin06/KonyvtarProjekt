namespace Konyvtar.Dtos
{
    public class KonyvekTopStatDto
    {
        public int Id { get; set; }
        public string Cim_hun { get; set; }
        public string Cim { get; set; }
        List<SzerzokForTop> Szerzok {  get; set; }
        List<MufajokForTop> Mufajok { get; set;}

    }
}
