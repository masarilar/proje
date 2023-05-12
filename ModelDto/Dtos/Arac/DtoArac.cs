using ModelDto.Dtos.AracTipi;
using ModelDto.Enums;

namespace ModelDto.Dtos.Arac
{
    public class DtoArac
    {
        public int Id { get; set; }
        public VeriDurumu Durum { get; set; }
        public int KaydedenId { get; set; }
        public int DegistirenId { get; set; }
        public DateTime KayitTarih { get; set; }
        public DateTime DegisiklikTarih { get; set; }
        public int AracTipiId { get; set; }
        public string Marka { get; set; }
        public string ModelYili { get; set; }
        public string Rengi { get; set; }
        public AracDemirbasDurumu DemirbasDurumu { get; set; }
        public string BaslangicKilometresi { get; set; }
        public AracKilometredeBakimaGider KilometredeBakimaGider { get; set; }
        public string Plakasi { get; set; }
        public string RuhsatNo { get; set; }
        public string Resimleri { get; set; }
        public DtoAracTipi AracTipi { get; set; }
    }
}
