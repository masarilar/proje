using ModelDto.Dtos.Arac;
using ModelDto.Dtos.AracBeklemeDurum;
using ModelDto.Dtos.Sofor;
using ModelDto.Enums;

namespace ModelDto.Dtos.AracTalep
{
    public class DtoAracTalep
    {
        public int Id { get; set; }
        public VeriDurumu Durum { get; set; }
        public int KaydedenId { get; set; }
        public int DegistirenId { get; set; }
        public DateTime KayitTarih { get; set; }
        public DateTime DegisiklikTarih { get; set; }
        public string BaslangicNoktasi { get; set; }
        public string BitisNoktasi { get; set; }
        public string ToplamKilometre { get; set; }
        public DateTime GidisTarihSaat { get; set; }
        public int AracBeklemeDurumId { get; set; }
        public DtoAracBeklemeDurum AracBeklemeDurum { get; set; }
        public AracTalepDurum AracTalepDurum { get; set; }
        public int? AracId { get; set; }
        public int? SoforId { get; set; }
    }

}
