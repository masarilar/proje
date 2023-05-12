using ModelDto.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDto.Dtos.AracBeklemeDurum
{
    public class DtoAracBeklemeDurumSil
    {
        public int Id { get; set; }
        public VeriDurumu Durum { get; set; }
    }
}
