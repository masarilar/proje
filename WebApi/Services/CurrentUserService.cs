using Application.Interfaces;
using System.Security.Claims;

namespace WebApi.Services {
    public class CurrentUserService : ICurrentUserService {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor) {
            _httpContextAccessor = httpContextAccessor;
        }

        public int? KullaniciId {
            get {
                var parsed = int.TryParse(_httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier), out var val);
                return parsed ? val : null;
            }
        }
        public string KullaniciAdi => _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.GivenName);
        public string Ad => _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Name);
        public string Soyad => _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Surname);
        public ClaimsPrincipal Principal => _httpContextAccessor?.HttpContext?.User;
    }
}
