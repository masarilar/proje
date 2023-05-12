using FluentValidation;

namespace ModelDto.Dtos.KategoriTip
{
    public class DtoKategoriTipKaydet
    {
        public int? Id { get; set; }
        public string? TipAdi { get; set; }
    }
    public class DtoKategoriTipKaydetValidator : AbstractValidator<DtoKategoriTipKaydet>
    {
        public DtoKategoriTipKaydetValidator()
        {
            RuleFor(e => e.TipAdi).NotNull().WithMessage("Tip Adı boş bırakılamaz.")
                                    .NotEmpty().WithMessage("Tip Adı boş geçilemez.")
                                    .MaximumLength(250).WithMessage("Tip Adı 250 karakterden uzun olamaz.");
        }
    }
}
