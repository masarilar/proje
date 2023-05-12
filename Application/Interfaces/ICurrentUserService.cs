using System.Security.Claims;

namespace Application.Interfaces {
    public interface ICurrentUserService {
        int? KullaniciId { get; }
        string KullaniciAdi { get; }
        string Ad { get; }
        string Soyad { get; }
        ClaimsPrincipal Principal { get; }
    }
}
