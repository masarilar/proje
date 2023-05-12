namespace ModelDto.Dtos.Genel {
    public class GenelSonuc<T> {
        public GenelSonuc() : this(false) {

        }
        public GenelSonuc(bool basarili) {
            Basarili = basarili;
        }

        public bool Basarili;
        public T Sonuc;
        public string KullaniciMesaji;
        public Exception SistemHatasiEx;
    }
}
