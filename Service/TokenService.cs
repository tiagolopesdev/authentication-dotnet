using fiap_jwt_api.Interfaces;
using fiap_jwt_api.Model;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace fiap_jwt_api.Service
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetToken(Users users)
        {
            var userExist = ListUsers.Users.Any(item => item.Name.Equals(users.Name) && item.Password.Equals(users.Password));

            if (!userExist) return string.Empty;

            var tokenHandler = new JwtSecurityTokenHandler();

            var keyEncryption = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("SecretJWT"));

            var tokenProperties = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, users.Name),
                    new Claim(ClaimTypes.Role, (users.Permissions).ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyEncryption), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenProperties);
            return tokenHandler.WriteToken(token);
        }
    }
}
