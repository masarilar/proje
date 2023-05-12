using FluentValidation;

namespace ModelDto.Dtos.Calisma
{
    public class DtoCalismaTurKaydet
    {
        public int? Id { get; set; }
        public string? Adi { get; set; }
    }

    public class DtoCalismaTurKaydetValidator : AbstractValidator<DtoCalismaTurKaydet>
    {
        public DtoCalismaTurKaydetValidator()
        {
            RuleFor(e => e.Adi).NotNull().WithMessage("Çalışma Türü boş bırakılamaz.")
                                    .NotEmpty().WithMessage("Çalışma Türü boş geçilemez.")
                                    .MaximumLength(250).WithMessage("Çalışma Türü 250 karakterden uzun olamaz.");
        }
    }
}
