using FluentValidation;

namespace ModelDto.Dtos.AracTipi
{
    public class DtoAracTipiKaydet
    {
        public int? Id { get; set; }
        public string? Adi { get; set; }
    }

    public class DtoAracTipiKaydetValidator : AbstractValidator<DtoAracTipiKaydet>
    {
        public DtoAracTipiKaydetValidator()
        {
            RuleFor(e => e.Adi).NotNull().WithMessage("Araç Tip Adı boş bırakılamaz.")
                                         .NotEmpty().WithMessage("Araç Tip Adı boş geçilemez.")
                                         .MaximumLength(250).WithMessage("Araç Tip Adı 250 karakterden uzun olamaz");
        }
    }
}
