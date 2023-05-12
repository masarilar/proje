using Application.Interfaces;
using Application.Interfaces.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Identity {
    public class JwtToken : IJwtToken {
        private readonly IConfiguration _configuration;
        private readonly IKullaniciRepository _kullaniciRepository;

        public JwtToken(IConfiguration configuration, IKullaniciRepository kullaniciRepository) {
            _configuration = configuration;
            _kullaniciRepository = kullaniciRepository;
        }

        public string GenerateToken(IEnumerable<Claim> claims) {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            var token = new JwtSecurityToken(
              _configuration["JWT:Issuer"],
              _configuration["JWT:Audience"],
              claims,
              expires: DateTime.Now.AddHours(2),
              signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256));
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<string> GenerateToken(int kullaniciId) {
            var kullanici = await _kullaniciRepository.GetByIdAsync(kullaniciId);

             var claims = new List<Claim> {
               new Claim(ClaimTypes.NameIdentifier, kullanici.Id.ToString()),
               new Claim(ClaimTypes.GivenName, kullanici.Ad),             
               new Claim(ClaimTypes.Name, kullanici.Ad),
               new Claim(ClaimTypes.Surname, kullanici.Soyad),
             };
            return GenerateToken(claims);
        }
    }
}
