using Metafar.ATM.Challenge.Domain.Interfaces;
using Metafar.ATM.Challenge.Domain.Settings;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Metafar.ATM.Challenge.Application.Services
{
    public class JwtTokenGenerator : ITokenGenerator
    {
        private JwtTokenSettings _jwtTokenSettings;

        public JwtTokenGenerator(IOptions<JwtTokenSettings> options)
        {
            _jwtTokenSettings = options.Value;
        }

        public string GenerateToken(Dictionary<string, string> parameters)
        {
            try
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtTokenSettings.SecurityKey));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var claims = new List<Claim>();

                foreach (var item in parameters)
                {
                    claims.Add(new Claim(item.Key, item.Value));
                }

                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Issuer = _jwtTokenSettings.Issuer,
                    Audience = _jwtTokenSettings.Audience,
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.UtcNow.AddHours(_jwtTokenSettings.TokenExpirationHours),
                    SigningCredentials = credentials
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
