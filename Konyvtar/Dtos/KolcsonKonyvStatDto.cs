namespace Konyvtar.Dtos
{
    public class KolcsonKonyvStatDto
    {
        public int Id { get; set; }
        public string Cim_hun { get; set; }
        public string Cim { get; set; }
        public string Szerzo { get; set; }
        public string Mufaj { get; set; }
        public DateTime Visszahozatal_hatarido { get; set; }
        public bool Visszahozatal_lejart {  get; set; }
        List<DiakokForStatDto> Kolcsonzo_Diak { get; set; }
    }
}
