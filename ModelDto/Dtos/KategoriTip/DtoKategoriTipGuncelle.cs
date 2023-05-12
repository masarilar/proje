using FluentValidation;

namespace ModelDto.Dtos.KategoriTip
{
    public class DtoKategoriTipGuncelle
    {
        public int Id { get; set; }
        public string? TipAdi { get; set; }
    }
    public class DtoKategoriTipGuncelleValidator : AbstractValidator<DtoKategoriTipGuncelle>
    {
        public DtoKategoriTipGuncelleValidator()
        {
            //RuleFor(e => e.Id).GreaterThan(0).WithMessage("{PropertyName} '0' dan büyük olmalı.");
            RuleFor(e => e.TipAdi).NotNull().WithMessage("Tip Adı boş bırakılamaz.")
                                    .NotEmpty().WithMessage("Tip Adı boş geçilemez.")
                                    .MaximumLength(250).WithMessage("Tip Adı 250 karakterden uzun olamaz.");
        }
    }
}
