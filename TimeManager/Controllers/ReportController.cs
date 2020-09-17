using Microsoft.AspNetCore.Mvc;
using TimeManager.Service;

namespace TimeManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController : ControllerBase
    {
        ReportService _service;

        public ReportController(ReportService service)
        {
            _service = service;
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
    }
}
