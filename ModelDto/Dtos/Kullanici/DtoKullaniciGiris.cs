using FluentValidation;

namespace ModelDto.Dtos.Kullanici
{
    public class DtoKullaniciGiris
    {
        public string Eposta { get; set; }
        public string Parola { get; set; }
    }

    public class DtoKullaniciGirisValidator : AbstractValidator<DtoKullaniciGiris>
    {
        public DtoKullaniciGirisValidator()
        {
            RuleFor(e => e.Eposta).NotNull().NotEmpty().MaximumLength(250);
            RuleFor(e => e.Parola).NotNull().NotEmpty().MaximumLength(250);
        }
    }
}