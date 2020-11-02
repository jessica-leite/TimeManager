using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TimeManager.DTO;
using TimeManager.Service;

namespace TimeManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ActivityController : BaseController
    {
        private readonly ActivityService _service;

        public ActivityController(ActivityService service)
        {
            _service = service;
        }

        [HttpPost]
        public ActionResult Create([FromBody] ActivityDTO activity)
        {
            _service.Add(activity, GetCurrentUserId());

            var uri = Url.Action(nameof(GetById), new { id = activity.Id });
            return Created(uri, activity);
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            return Ok(_service.GetById(id));
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var userId = GetCurrentUserId();
            return Ok(_service.GetAll(userId));
        }

        [HttpDelete("{id}")]
        public ActionResult Remove(int id)
        {
            _service.Remove(id);
            return NoContent();
        }

        [HttpPut]
        public ActionResult Update([FromBody] ActivityDTO activity)
        {
            _service.Update(activity, GetCurrentUserId());
            return Ok(activity);
        }
    }
}
