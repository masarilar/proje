using FluentValidation;
using ModelDto.Dtos.Dosya;
using ModelDto.Dtos.Genel;

namespace ModelDto.Dtos.Sofor
{
    public class DtoSoforGuncelle
    {
        public int Id { get; set; }
        public int KullaniciId { get; set; }
        public string? Resim { get; set; }
        public string? EhliyetYetkinlikleri { get; set; }
        public DtoDosyaYukle? DosyaYukle { get; set; }
        public List<DtoDosya>? YuklenmisDosya { get; set; }
    }

    public class DtoSoforGuncelleValidator : AbstractValidator<DtoSoforGuncelle>
    {
        public DtoSoforGuncelleValidator()
        {
            //RuleFor(e => e.Id).GreaterThan(0).WithMessage("{PropertyName} '0' dan büyük olmalı.");

            RuleFor(e => e.KullaniciId).GreaterThan(0).WithMessage("Şoför Adı Soyadı boş bırakılamaz.");

            RuleFor(e => e.Resim).NotNull().WithMessage("Resim boş bırakılamaz.")
               .NotEmpty().WithMessage("Resim boş geçilemez.")
                                     .MaximumLength(int.MaxValue);

            RuleFor(e => e.EhliyetYetkinlikleri).NotNull().WithMessage("Ehliyet Yetkinlikleri boş bırakılamaz.")
          .NotEmpty().WithMessage("Ehliyet Yetkinlikleri boş geçilemez.");
        }
    }
}
