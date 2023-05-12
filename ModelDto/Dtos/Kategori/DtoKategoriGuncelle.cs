using FluentValidation;

namespace ModelDto.Dtos.Kategori
{
    public class DtoKategoriGuncelle
    {
        public int Id { get; set; }
        public string? Ad { get; set; }
        public int? KategoriTipId { get; set; }
        public string? Yetkileri { get; set; }
    }

    public class DtoKategoriGuncelleValidator : AbstractValidator<DtoKategoriGuncelle>
    {
        public DtoKategoriGuncelleValidator()
        {
            //RuleFor(e => e.Id).GreaterThan(0).WithMessage("{PropertyName} '0' dan büyük olmalı.");
            RuleFor(e => e.Ad).NotNull().WithMessage("Kategori Adı boş bırakılamaz.")
                                     .NotEmpty().WithMessage("Kategori Adı boş geçilemez.")
                                     .MaximumLength(250).WithMessage("Kategori Adı 250 karakterden uzun olamaz.");
            RuleFor(e => e.KategoriTipId).NotEmpty().WithMessage("Kategori Tipi boş bırakılamaz.");
            RuleFor(e => e.Yetkileri).NotNull().WithMessage("Kategori Yetkileri boş bırakılamaz.")
                                              .MaximumLength(int.MaxValue);
        }
    }
}