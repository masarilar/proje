namespace ModelDto.Dtos.Genel {
    public class DtoDosyaYukle : IDosyaYukleIstek {
        public byte[] Dosya { get; set; }
        public string DosyaAdi { get; set; }
        public string DosyaUzantisi { get; set; }
    }
}
