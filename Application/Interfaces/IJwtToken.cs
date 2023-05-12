using System.Security.Claims;

namespace Application.Interfaces {
    public interface IJwtToken {
        Task<string> GenerateToken(int kullaniciId);
        string GenerateToken(IEnumerable<Claim> claims);
    }
}
