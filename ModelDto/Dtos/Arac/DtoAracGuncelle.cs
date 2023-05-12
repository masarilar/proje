using FluentValidation;
using ModelDto.Dtos.Dosya;
using ModelDto.Dtos.Genel;
using ModelDto.Enums;

namespace ModelDto.Dtos.Arac
{
    public class DtoAracGuncelle
    {
        public int Id { get; set; }
        public int AracTipiId { get; set; }
        public string? Marka { get; set; }
        public string? ModelYili { get; set; }
        public string? Rengi { get; set; }
        public AracDemirbasDurumu? DemirbasDurumu { get; set; }
        public string? BaslangicKilometresi { get; set; }
        public AracKilometredeBakimaGider? KilometredeBakimaGider { get; set; }
        public string? Plakasi { get; set; }
        public string? RuhsatNo { get; set; }
        public string? Resimleri { get; set; }
        public DtoDosyaYukle? DosyaYukle { get; set; }
        public List<DtoDosya>? YuklenmisDosya { get; set; }
    }
    public class DtoAracGuncelleValidator : AbstractValidator<DtoAracGuncelle>
    {
        public DtoAracGuncelleValidator()
        {
            //RuleFor(e => e.Id).GreaterThan(0).WithMessage("{PropertyName} '0' dan büyük olmalı.");

            RuleFor(e => e.AracTipiId).GreaterThan(0).WithMessage("Araç Tipi Adı boş bırakılamaz.");

            RuleFor(e => e.Marka).NotNull().WithMessage("Marka boş bırakılamaz.")
           .NotEmpty().WithMessage("Marka boş geçilemez.")
           .MaximumLength(250).WithMessage("Marka 250 karakterden uzun olamaz");

            RuleFor(e => e.ModelYili).NotNull().WithMessage("Model Yılı boş bırakılamaz.")
           .NotEmpty().WithMessage("Model Yılı boş geçilemez.")
           .MaximumLength(250).WithMessage("Model Yılı 250 karakterden uzun olamaz");

            RuleFor(e => e.Rengi).NotNull().WithMessage("Renk boş bırakılamaz.")
           .NotEmpty().WithMessage("Renk boş geçilemez.")
           .MaximumLength(250).WithMessage("Renk 250 karakterden uzun olamaz");

            RuleFor(e => e.DemirbasDurumu).IsInEnum().NotEmpty().WithMessage("Demirbaş Durumu boş bırakılamaz.");

            RuleFor(e => e.BaslangicKilometresi).NotNull().WithMessage("Başlangıç Kilometresi boş bırakılamaz.")
           .NotEmpty().WithMessage("Başlangıç Kilometresi boş geçilemez.")
           .MaximumLength(250).WithMessage("Başlangıç Kilometresi 250 karakterden uzun olamaz");

            RuleFor(e => e.KilometredeBakimaGider).IsInEnum().NotEmpty().WithMessage("Kaç Kilometrede Bakıma Gider boş bırakılamaz.");

            RuleFor(e => e.Plakasi).NotNull().WithMessage("Plaka boş bırakılamaz.")
           .NotEmpty().WithMessage("Plaka boş geçilemez.")
           .MaximumLength(10).WithMessage("Plaka 10 karakterden uzun olamaz");

            RuleFor(e => e.RuhsatNo).NotNull().WithMessage("Ruhsat No boş bırakılamaz.")
           .NotEmpty().WithMessage("Ruhsat No boş geçilemez.")
           .MaximumLength(8).WithMessage("Ruhsat No 8 karakterden uzun olamaz");

            RuleFor(e => e.Resimleri).MaximumLength(int.MaxValue);
        }
    }
}
