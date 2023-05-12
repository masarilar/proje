using FluentValidation;
using ModelDto.Dtos.Dosya;
using ModelDto.Dtos.Genel;

namespace ModelDto.Dtos.Duyuru
{
    public class DtoDuyuruGuncelle
    {
        public int Id { get; set; }
        public int KategoriId { get; set; }
        public string Basligi { get; set; }
        public string? AnaResim { get; set; }
        public string Metin { get; set; }
        public DateTime? YayinTarih { get; set; }
        public DateTime? YayinBitisTarih { get; set; }
        public string KeywordAlani { get; set; }
        public int? SliderGoster { get; set; }
        public int? SliderSirasi { get; set; }
        public int? YorumEkle { get; set; }
        public int? Begenme { get; set; }
        public DtoDosyaYukle? DosyaYukle { get; set; }
        public List<DtoDosya>? YuklenmisDosya { get; set; }
    }

    public class DtoDuyuruGuncelleValidator : AbstractValidator<DtoDuyuruGuncelle>
    {
        public DtoDuyuruGuncelleValidator()
        {
            //RuleFor(e => e.Id).GreaterThan(0).WithMessage("{PropertyName} '0' dan büyük olmalı.");
            RuleFor(e => e.KategoriId).GreaterThan(0).WithMessage("Kategori boş bırakılamaz.");
            RuleFor(e => e.Basligi).NotNull().WithMessage("Başlık boş bırakılamaz.")
                                         .NotEmpty().WithMessage("Başlık boş geçilemez.")
                                         .MaximumLength(200).WithMessage("Başlık 200 karakterden uzun olamaz.");
            RuleFor(e => e.AnaResim).MaximumLength(int.MaxValue);
            RuleFor(e => e.Metin).NotNull().WithMessage("Metin boş bırakılamaz.")
                                       .NotEmpty().WithMessage("Metin boş geçilemez.")
                                       .MaximumLength(int.MaxValue);
            RuleFor(e => e.YayinTarih).NotNull().WithMessage("Yayın Tarihi null olamaz.");
            RuleFor(e => e.YayinBitisTarih).NotNull().WithMessage("Yayın Bitiş Tarihi null olamaz.");
            RuleFor(e => e.KeywordAlani).NotNull().WithMessage("Keyword Alanı boş bırakılamaz.")
                                              .NotEmpty().WithMessage("Keyword Alanı boş geçilemez.")
                                              .MaximumLength(int.MaxValue);
            RuleFor(e => e.SliderGoster).GreaterThan(0).WithMessage("Slider Göster boş bırakılamaz.");
            RuleFor(e => e.SliderSirasi).GreaterThan(0).WithMessage("Slider Sırası boş bırakılamaz.");
            RuleFor(e => e.YorumEkle).GreaterThan(0).WithMessage("Yorum Ekle boş bırakılamaz.");
            RuleFor(e => e.Begenme).GreaterThan(0).WithMessage("Beğenme boş bırakılamaz.");
        }
    }
}
