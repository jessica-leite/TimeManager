using Microsoft.AspNetCore.Mvc;
using TimeManager.DTO;
using TimeManager.Service;

namespace TimeManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : BaseController
    {
        private readonly LoginService _service;

        public LoginController(LoginService service)
        {
            _service = service;
        }

        [HttpPost]
        public ActionResult GetToken([FromBody] LoginDTO login)
        {
            return Ok(_service.GetToken(login));
        }


        [HttpPost("password")]
        public ActionResult ResetPassword([FromBody] ResetPasswordDTO resetPassword)
        {
            var resetedPassword = _service.ResetPassword(resetPassword);

            if (resetedPassword)
            {
                return Ok();
            }

            return BadRequest(resetPassword);
        }
    }
}