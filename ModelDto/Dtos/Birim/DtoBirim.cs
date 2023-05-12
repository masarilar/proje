using ModelDto.Enums;

namespace ModelDto.Dtos.Birim
{
    public class DtoBirim
    {
        public int Id { get; set; }
        public VeriDurumu Durum { get; set; }
        public int KaydedenId { get; set; }
        public int DegistirenId { get; set; }
        public DateTime KayitTarih { get; set; }
        public DateTime DegisiklikTarih { get; set; }
        public string Adi { get; set; }
        public int? UstBirimId { get; set; }
        public DtoBirim UstBirim { get; set; }
    }
}
