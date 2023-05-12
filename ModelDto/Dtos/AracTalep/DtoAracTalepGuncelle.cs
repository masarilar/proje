using FluentValidation;
using ModelDto.Dtos.Arac;
using ModelDto.Dtos.Sofor;
using ModelDto.Enums;

namespace ModelDto.Dtos.AracTalep
{
    public class DtoAracTalepGuncelle
    {
        public int Id { get; set; }
        public string BaslangicNoktasi { get; set; }
        public string BitisNoktasi { get; set; }
        public string ToplamKilometre { get; set; }
        public DateTime GidisTarihSaat { get; set; }
        public int AracBeklemeDurumId { get; set; }
        public int? AracTalepDurum { get; set; }
        public int? AracId { get; set; }
        public int? SoforId { get; set; }
    }
    public class DtoAracTalepGuncelleValidator : AbstractValidator<DtoAracTalepGuncelle>
    {
        public DtoAracTalepGuncelleValidator()
        {
            RuleFor(e => e.BaslangicNoktasi).NotNull().WithMessage("Başlangıç Noktası boş bırakılamaz.")
           .NotEmpty().WithMessage("Başlangıç Noktası boş geçilemez.")
           .MaximumLength(250).WithMessage("Başlangıç Noktası 250 karakterden uzun olamaz");
            RuleFor(e => e.BitisNoktasi).NotNull().WithMessage("Bitiş Noktası boş bırakılamaz.")
           .NotEmpty().WithMessage("Bitiş Noktası boş geçilemez.")
           .MaximumLength(250).WithMessage("Bitiş Noktası 250 karakterden uzun olamaz");
            RuleFor(e => e.ToplamKilometre).NotNull().WithMessage("Toplam Kilometre boş bırakılamaz.")
           .NotEmpty().WithMessage("Toplam Kilometre boş geçilemez.")
           .MaximumLength(250).WithMessage("Toplam Kilometre 250 karakterden uzun olamaz");
            RuleFor(e => e.GidisTarihSaat).NotNull().WithMessage("Gidiş Tarih Saat boş bırakılamaz.");
            RuleFor(e => e.AracBeklemeDurumId);
        }
    }
}
