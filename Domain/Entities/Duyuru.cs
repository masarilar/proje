using Domain.Base;
using ModelDto.Enums;

namespace Domain.Entities {
    public class Duyuru : IEntity<int> {
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
        public DuyuruSliderGoster SliderGoster { get; set; }
        public int SliderSirasi { get; set; }
        public DuyuruYorumEkle YorumEkle { get; set; }
        public DuyuruBegenme Begenme { get; set; }

        public Kategori Kategori { get; set; }
    }
}
