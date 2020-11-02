using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TimeManager.DTO;
using TimeManager.Service;

namespace TimeManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UserController : BaseController
    {
        private readonly UserService _service;

        public UserController(UserService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Create([FromBody] UserDTO user)
        {
            _service.Add(user);

            var uri = Url.Action(nameof(GetById), new { id = user.Id });
            return Created(uri, user);
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            return Ok(_service.GetById(id));
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpDelete("{id}")]
        public ActionResult Remove(int id)
        {
            _service.Remove(id);
            return NoContent();
        }

        [HttpPut]
        public ActionResult Update([FromBody] UserDTO user)
        {
            _service.Update(user);
            return Ok(user);
        }
    }
}
