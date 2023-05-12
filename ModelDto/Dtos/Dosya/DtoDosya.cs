using FluentValidation;
using ModelDto.Enums;

namespace ModelDto.Dtos.Dosya {
    public class DtoDosya {
        public int Id { get; set; }
        public DateTime? KayitTarih { get; set; }
        public string Adi { get; set; }
        public string Yol { get; set; }
        public string Uzanti { get; set; }
        public ReferansTipleri RefTip { get; set; }
        public int RefId { get; set; }
    }

    public class DtoDosyaKaydetValidator : AbstractValidator<DtoDosya> {
        public DtoDosyaKaydetValidator() {
            RuleFor(e => e.Adi).NotNull().NotEmpty().MaximumLength(250);
            RuleFor(e => e.Yol).NotNull().NotEmpty().MaximumLength(int.MaxValue);
            RuleFor(e => e.Uzanti).NotNull().NotEmpty().MaximumLength(128);
            RuleFor(e => e.RefTip).IsInEnum();
            RuleFor(e => e.RefId).GreaterThan(0);
        }
    }
}
