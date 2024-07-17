using DynamicFormBuilder.Core.Models;
using DynamicFormBuilder.Core.Repositories;
using DynamicFormBuilder.Core.Services;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DynamicFormBuilder.Service.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;

        public AuthService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public async Task<User> LoginAsync(string username, string password)
        {
            return await _authRepository.LoginAsync(username, password);
        }

        public string GenerateJWT(string username)
        {
            try
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MySuperSecretKeyForDynamicFormBuilder")); 
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, username),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                var token = new JwtSecurityToken(
                    issuer: "dynamicAudience.com",
                    audience: "dynamicAudience.com",
                    claims: claims,
                    expires: DateTime.UtcNow.AddMinutes(30), // DateTime.UtcNow kullanın
                    signingCredentials: credentials);

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception ex)
            {
                // Hata mesajını loglayın
                Console.WriteLine($"Error generating JWT: {ex.Message}");
                return ex.ToString();
            }
        }


    }
}
