using ModelDto.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Base {
    public interface IEntity<T> {
        T Id { get; set; }
        VeriDurumu Durum { get; set; }
        T KaydedenId { get; set; }
        T DegistirenId { get; set; }
        DateTime KayitTarih { get; set; }
        DateTime DegisiklikTarih { get; set; }
    }
}
