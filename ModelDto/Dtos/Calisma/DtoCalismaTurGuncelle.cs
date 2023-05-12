using FluentValidation;

namespace ModelDto.Dtos.Calisma
{
    public class DtoCalismaTurGuncelle
    {
        public int Id { get; set; }
        public string? Adi { get; set; }
    }

    public class DtoCalismaTurGuncelleValidator : AbstractValidator<DtoCalismaTurGuncelle>
    {
        public DtoCalismaTurGuncelleValidator()
        {
            //RuleFor(e => e.Id).GreaterThan(0).WithMessage("Id '0' dan büyük olmalı.");
            RuleFor(e => e.Adi).NotNull().WithMessage("Çalışma Türü boş bırakılamaz.")
                                    .NotEmpty().WithMessage("Çalışma Türü boş geçilemez.")
                                    .MaximumLength(250).WithMessage("Çalışma Türü 250 karakterden uzun olamaz.");
        }
    }
}
