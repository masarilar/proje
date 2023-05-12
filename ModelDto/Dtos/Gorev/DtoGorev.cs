using ModelDto.Enums;

namespace ModelDto.Dtos.Gorev
{
    public class DtoGorev
    {
        public int Id { get; set; }
        public VeriDurumu Durum { get; set; }
        public int KaydedenId { get; set; }
        public int DegistirenId { get; set; }
        public DateTime KayitTarih { get; set; }
        public DateTime DegisiklikTarih { get; set; }
        public string Adi { get; set; }
    }
}
