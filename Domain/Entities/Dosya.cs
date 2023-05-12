using Domain.Base;
using ModelDto.Enums;

namespace Domain.Entities {
    public class Dosya : IEntity<int> {
        public int Id { get; set; }
        public VeriDurumu Durum { get; set; }
        public int KaydedenId { get; set; }
        public int DegistirenId { get; set; }
        public DateTime KayitTarih { get; set; }
        public DateTime DegisiklikTarih { get; set; }
        public string Adi { get; set; }
        public string Yol { get; set; }
        public string Uzanti { get; set; }
        public ReferansTipleri RefTip { get; set; }
        public int RefId { get; set; }
    }
}
