using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using TimeManager.Domain.Context;
using TimeManager.DTO;

namespace TimeManager.Service
{
    public class LoginService
    {
        private readonly TimeManagerContext _context;

        public LoginService(TimeManagerContext context)
        {
            _context = context;
        }

        public JwtSecurityToken GetToken(LoginDTO login)
        {
            var validUser = _context.User.Any(u => u.Email == login.Email && u.Password == login.Password);

            if (validUser)
            {

            }

            return null;
        }
    }
}
