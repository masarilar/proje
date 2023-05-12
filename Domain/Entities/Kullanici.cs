using Domain.Base;
using ModelDto.Enums;

namespace Domain.Entities
{
    public class Kullanici : IEntity<int>
    {
        public int Id { get; set; }
        public VeriDurumu Durum { get; set; }
        public int KaydedenId { get; set; }
        public int DegistirenId { get; set; }
        public DateTime KayitTarih { get; set; }
        public DateTime DegisiklikTarih { get; set; }
        public string TC { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string AdSoyad { get; set; }
        public DateTime DogumTarihi { get; set; }
        public string Eposta { get; set; }
        public string Parola { get; set; }
        public string Resim { get; set; }
        public int BirimId { get; set; }
        public int GorevId { get; set; }
        public string Adres { get; set; }
        public string CepTelefon { get; set; }
        public string? EvTelefon { get; set; }
        public string? DahiliNo { get; set; }
        public string YakiniAdSoyad { get; set; }
        public string YakiniTelefon { get; set; }
        public string KanGrubu { get; set; }
        public Cinsiyet Cinsiyet { get; set; }
        public MedeniDurum MedeniDurum { get; set; }
        public AskerlikDurum AskerlikDurum { get; set; }
        public string? FirmaSicilNo { get; set; }
        public int CalismaTurId { get; set; }
        public Birim Birim { get; set; }
        public CalismaTur CalismaTur { get; set; }
        public Gorev Gorev { get; set; }

    }
}
