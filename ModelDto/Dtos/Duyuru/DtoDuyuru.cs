using ModelDto.Dtos.Kategori;
using ModelDto.Enums;

namespace ModelDto.Dtos.Duyuru
{
    public class DtoDuyuru
    {
        public int Id { get; set; }
        public VeriDurumu Durum { get; set; }
        public int KaydedenId { get; set; }
        public DateTime KayitTarih { get; set; }
        public int DegistirenId { get; set; }
        public DateTime DegisiklikTarih { get; set; }
        public int KategoriId { get; set; }
        public string Basligi { get; set; }
        public string? AnaResim { get; set; }
        public string Metin { get; set; }
        public DateTime YayinTarih { get; set; }
        public DateTime YayinBitisTarih { get; set; }
        public string KeywordAlani { get; set; }
        public int SliderGoster { get; set; }
        public int SliderSirasi { get; set; }
        public int YorumEkle { get; set; }
        public int Begenme { get; set; }
        public DtoKategori Kategori { get; set; }
    }
}
