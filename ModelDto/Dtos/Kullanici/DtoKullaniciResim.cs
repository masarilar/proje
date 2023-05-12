using FluentValidation;

namespace ModelDto.Dtos.Kullanici
{
    public class DtoKullaniciResim
    {
        public string Resim { get; set; }
    }
    public class DtoKullaniciResimValidator : AbstractValidator<DtoKullaniciResim>
    {
        public DtoKullaniciResimValidator()
        {
            RuleFor(e => e.Resim).NotNull().NotEmpty().MaximumLength(int.MaxValue);
        }
    }
}
