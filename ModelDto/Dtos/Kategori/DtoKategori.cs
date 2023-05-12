using ModelDto.Dtos.KategoriTip;
using ModelDto.Enums;

namespace ModelDto.Dtos.Kategori
{
    public class DtoKategori
    {
        public int Id { get; set; }
        public VeriDurumu Durum { get; set; }
        public int KaydedenId { get; set; }
        public DateTime KayitTarih { get; set; }
        public int DegistirenId { get; set; }
        public DateTime DegisiklikTarih { get; set; }
        public string Ad { get; set; }
        public int KategoriTipId { get; set; }
        public string Yetkileri { get; set; }
        public DtoKategoriTip KategoriTip { get; set; }

    }
}
