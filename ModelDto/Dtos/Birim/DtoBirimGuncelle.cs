using FluentValidation;

namespace ModelDto.Dtos.Birim
{
    public class DtoBirimGuncelle
    {
        public int Id { get; set; }
        public string? Adi { get; set; }
        public int UstBirimId { get; set; }
    }

    public class DtoBirimGuncelleValidator : AbstractValidator<DtoBirimGuncelle>
    {
        public DtoBirimGuncelleValidator()
        {
            //RuleFor(e => e.Id).GreaterThan(0).WithMessage("{PropertyName} '0' dan büyük olmalı.");
            RuleFor(e => e.Adi).NotNull().WithMessage("Birim Adı boş bırakılamaz.")
           .NotEmpty().WithMessage("Birim Adı boş geçilemez.")
           .MaximumLength(250).WithMessage("Birim Adı 250 karakterden uzun olamaz");
            RuleFor(e => e.UstBirimId).GreaterThan(0).WithMessage("Üst Birim Adı boş bırakılamaz.");
        }
    }
}
