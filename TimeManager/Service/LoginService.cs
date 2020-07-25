using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using TimeManager.Domain.Context;
using TimeManager.DTO;
using TimeManager.Settings;

namespace TimeManager.Service
{
    public class LoginService
    {
        private readonly TimeManagerContext _context;

        public LoginService(TimeManagerContext context)
        {
            _context = context;
        }

        public string GetToken(LoginDTO login)
        {
            var user = _context.User.FirstOrDefault(u => u.Email == login.Email && u.Password == login.Password);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Constants.JwtSecret);

            var expiresIn = DateTime.UtcNow.AddDays(15);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Name, user.Name)
                }),
                Expires = expiresIn,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var accessToken = tokenHandler.WriteToken(token);

            return accessToken; 
        }
    }
}
