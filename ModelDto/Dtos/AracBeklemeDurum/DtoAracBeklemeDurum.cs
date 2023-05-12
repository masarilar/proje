using ModelDto.Dtos.Birim;
using ModelDto.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDto.Dtos.AracBeklemeDurum
{
    public class DtoAracBeklemeDurum
    {
        public int Id { get; set; }
        public VeriDurumu Durum { get; set; }
        public int KaydedenId { get; set; }
        public int DegistirenId { get; set; }
        public DateTime KayitTarih { get; set; }
        public DateTime DegisiklikTarih { get; set; }
        public string BeklemeDurum { get; set; }
    }
}
