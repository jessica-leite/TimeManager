using Microsoft.AspNetCore.Mvc;
using TimeManager.Service;

namespace TimeManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController : ControllerBase
    {
        ReportService _service;
        ActivityService _activityService;

        public ReportController(ReportService service, ActivityService activityService)
        {
            _service = service;
            _activityService = activityService;
        }

        [HttpGet]
        public ActionResult GetTotalCompletedHours()
        {
            return Ok(_service.GetTotalCompletedHours());
        }

        [HttpGet("ongoing/{id}")]
        public ActionResult GetOngoingActivities(int id)
        {
            return Ok(_service.GetOngoingActivities(id));
        }

        [HttpGet("week/{userId}")]
        public ActionResult GetHoursPerWeek(int userId)
        {
            return Ok(_activityService.GetHoursPerWeek(userId));
        }
    }
}
