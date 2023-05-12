using FluentValidation;
using ModelDto.Dtos.Dosya;
using ModelDto.Dtos.Genel;
using ModelDto.Enums;

namespace ModelDto.Dtos.Kullanici
{
    public class DtoKullaniciGuncelle 
    {
        public int Id { get; set; }
        public string? TC { get; set; }
        public string? Ad { get; set; }
        public string? Soyad { get; set; }
        public string? AdSoyad { get; set; }
        public DateTime? DogumTarihi { get; set; }
        public string? Eposta { get; set; }
        public string? Parola { get; set; }
        public string? Resim { get; set; }
        public int BirimId { get; set; }
        public int GorevId { get; set; }
        public string? Adres { get; set; }
        public string? CepTelefon { get; set; }
        public string? EvTelefon { get; set; }
        public string? DahiliNo { get; set; }
        public string? YakiniAdSoyad { get; set; }
        public string? YakiniTelefon { get; set; }
        public string? KanGrubu { get; set; }
        public Cinsiyet? Cinsiyet { get; set; }
        public MedeniDurum? MedeniDurum { get; set; }
        public AskerlikDurum? AskerlikDurum { get; set; }
        public string? FirmaSicilNo { get; set; }
        public int CalismaTurId { get; set; }
        public DtoDosyaYukle? DosyaYukle { get; set; }
        public List<DtoDosya>? YuklenmisDosya { get; set; }
    }
    public class DtoKullaniciGuncelleValidator : AbstractValidator<DtoKullaniciGuncelle>
    {
        public DtoKullaniciGuncelleValidator()
        {
            RuleFor(e => e.TC).NotNull().WithMessage("TC boş bırakılamaz.")
                             .NotEmpty().WithMessage("TC boş geçilemez.")
                             .MaximumLength(11).WithMessage("TC 11 karakterden uzun olamaz.");
            RuleFor(e => e.Ad).NotNull().WithMessage("Ad boş bırakılamaz.")
                               .NotEmpty().WithMessage("Ad boş geçilemez.")
                               .MaximumLength(250).WithMessage("Ad 250 karakterden uzun olamaz.");
            RuleFor(e => e.Soyad).NotNull().WithMessage("Soyad  boş bırakılamaz.")
                               .NotEmpty().WithMessage("Soyad boş geçilemez.")
                               .MaximumLength(250).WithMessage("Soyad 250 karakterden uzun olamaz.");
            RuleFor(e => e.AdSoyad).NotNull().WithMessage("Ad Soyad  boş bırakılamaz.")
                               .NotEmpty().WithMessage("Ad Soyad boş geçilemez.")
                               .MaximumLength(250).WithMessage("Ad Soyad 250 karakterden uzun olamaz.");
            RuleFor(e => e.DogumTarihi).NotNull().WithMessage("Doğum Tarihi boş bırakılamaz.");
            RuleFor(e => e.Eposta).NotNull().WithMessage("Eposta boş bırakılamaz.")
                               .NotEmpty().WithMessage("Eposta boş geçilemez.")
                               .MaximumLength(250).WithMessage("Eposta 250 karakterden uzun olamaz.");
            RuleFor(e => e.Parola).NotNull().WithMessage("Parola boş bırakılamaz.")
                               .NotEmpty().WithMessage("Parola boş geçilemez.")
                               .MaximumLength(250).WithMessage("Parola 250 karakterden uzun olamaz.");
            RuleFor(e => e.Resim).NotNull().WithMessage("Resim boş bırakılamaz.")
                 .NotEmpty().WithMessage("Resim boş geçilemez.")
                                       .MaximumLength(int.MaxValue);
            RuleFor(e => e.BirimId).GreaterThan(0).WithMessage("Birim boş bırakılamaz.");
            RuleFor(e => e.GorevId).GreaterThan(0).WithMessage("Görev boş bırakılamaz.");
            RuleFor(e => e.Adres).NotNull().WithMessage("Adres boş bırakılamaz.")
                                     .NotEmpty().WithMessage("Adres boş geçilemez.")
                                     .MaximumLength(int.MaxValue);
            RuleFor(e => e.CepTelefon).NotNull().WithMessage("Cep Telefonu boş bırakılamaz.")
                               .NotEmpty().WithMessage("Cep Telefonu boş geçilemez.")
                               .MaximumLength(11).WithMessage("Cep Telefonu 11 karakterden uzun olamaz.");
            RuleFor(e => e.EvTelefon).MaximumLength(11).WithMessage("Ev Telefonu 11 karakterden uzun olamaz.");
            RuleFor(e => e.DahiliNo).MaximumLength(11).WithMessage("Dahili No 11 karakterden uzun olamaz.");
            RuleFor(e => e.YakiniAdSoyad).NotNull().WithMessage("Yakını Ad Soyad boş bırakılamaz.")
                              .NotEmpty().WithMessage("Yakını Ad Soyad boş geçilemez.")
                              .MaximumLength(250).WithMessage("Yakını Ad Soyad 250 karakterden uzun olamaz.");
            RuleFor(e => e.YakiniTelefon).NotNull().WithMessage("Yakını Telefonu boş bırakılamaz.")
                          .NotEmpty().WithMessage("Yakını Telefonu boş geçilemez.")
                          .MaximumLength(11).WithMessage("Yakını Telefonu 11 karakterden uzun olamaz.");
            RuleFor(e => e.KanGrubu).NotNull().WithMessage("Kan Grubu boş bırakılamaz.")
                          .NotEmpty().WithMessage("Kan Grubu boş geçilemez.")
                          .MaximumLength(25).WithMessage("Kan Grubu 25 karakterden uzun olamaz.");
            RuleFor(e => e.Cinsiyet).IsInEnum().NotEmpty().WithMessage("Cinsiyet boş bırakılamaz.");
            RuleFor(e => e.MedeniDurum).IsInEnum().NotEmpty().WithMessage("Medeni Durumu boş bırakılamaz.");
            RuleFor(e => e.AskerlikDurum).IsInEnum().NotEmpty().WithMessage("Askerlik Durumu boş bırakılamaz.");
            RuleFor(e => e.FirmaSicilNo).MaximumLength(250).WithMessage("Firma Sicil No 250 karakterden uzun olamaz.");
            RuleFor(e => e.CalismaTurId).GreaterThan(0).WithMessage("Çalışma Türü boş bırakılamaz.");
            //RuleFor(e => e.DosyaYukle).SetValidator(new DtoDosyaYukleValidator()).WithMessage("Kullanıcı Resmi zorunludur.");
        }
    }
}
