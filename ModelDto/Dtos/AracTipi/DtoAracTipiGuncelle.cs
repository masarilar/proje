using FluentValidation;

namespace ModelDto.Dtos.AracTipi
{
    public class DtoAracTipiGuncelle
    {
        public int Id { get; set; }
        public string? Adi { get; set; }
    }

    public class DtoAracTipiGuncelleValidator : AbstractValidator<DtoAracTipiGuncelle>
    {
        public DtoAracTipiGuncelleValidator()
        {
            //RuleFor(e => e.Id).GreaterThan(0).WithMessage("{PropertyName} '0' dan büyük olmalı.");
            RuleFor(e => e.Adi).NotNull().WithMessage("Araç Tip Adı boş bırakılamaz.")
                                         .NotEmpty().WithMessage("Araç Tip Adı boş geçilemez.")
                                         .MaximumLength(250).WithMessage("Araç Tip Adı 250 karakterden uzun olamaz");
        }
    }
}
