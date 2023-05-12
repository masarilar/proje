using ModelDto.Dtos.Kullanici;
using ModelDto.Enums;


namespace ModelDto.Dtos.Sofor
{
    public class DtoSofor
    {
        public int Id { get; set; }
        public VeriDurumu Durum { get; set; }
        public int KaydedenId { get; set; }
        public int DegistirenId { get; set; }
        public DateTime KayitTarih { get; set; }
        public DateTime DegisiklikTarih { get; set; }
        public int KullaniciId { get; set; }
        public string Resim { get; set; }
        public string EhliyetYetkinlikleri { get; set; }
        public DtoKullanici Kullanici { get; set; }
    }
}
