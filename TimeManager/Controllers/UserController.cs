using Microsoft.AspNetCore.Mvc;
using System;
using TimeManager.DTO;
using TimeManager.Service;

namespace TimeManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _service;

        public UserController(UserService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult Create([FromBody] UserDTO user)
        {
            _service.Add(user);

            var uri = Url.Action(nameof(GetById), new { id = user.Id });
            return Created(uri, user);
        }

        public ActionResult GetById()
        {
            throw new NotImplementedException();
        }
    }
}
