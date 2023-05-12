using FluentValidation;
using ModelDto.Dtos.Birim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDto.Dtos.AracBeklemeDurum
{
    public class DtoAracBeklemeDurumKaydet
    {
        public int Id { get; set; }
        public string BeklemeDurum { get; set; }
    }
    public class DtoAracBeklemeDurumKaydetValidator : AbstractValidator<DtoAracBeklemeDurumKaydet>
    {
        public DtoAracBeklemeDurumKaydetValidator()
        {
            RuleFor(e => e.BeklemeDurum).NotNull().WithMessage("Bekleme Durumu boş bırakılamaz.")
           .NotEmpty().WithMessage("Bekleme Durumu boş geçilemez.")
           .MaximumLength(250).WithMessage("Bekleme Durumu 250 karakterden uzun olamaz");
        }
    }
}
