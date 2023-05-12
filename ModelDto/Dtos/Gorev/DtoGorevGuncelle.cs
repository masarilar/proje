using FluentValidation;

namespace ModelDto.Dtos.Gorev
{
    public class DtoGorevGuncelle
    {
        public int Id { get; set; }
        public string? Adi { get; set; }
    }

    public class DtoGorevGuncelleValidator : AbstractValidator<DtoGorevGuncelle>
    {
        public DtoGorevGuncelleValidator()
        {
            RuleFor(e => e.Adi).NotNull().WithMessage("Görev Adı boş bırakılamaz.")
                                    .NotEmpty().WithMessage("Görev Adı boş geçilemez.")
                                    .MaximumLength(250).WithMessage("Görev Adı 250 karakterden uzun olamaz.");
        }
    }
}
