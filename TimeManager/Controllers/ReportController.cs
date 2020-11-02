﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TimeManager.Service;

namespace TimeManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ReportController : BaseController
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
            var userId = GetCurrentUserId();
            return Ok(_service.GetTotalCompletedHours(userId));
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

        [HttpGet("month/{userId}")]
        public ActionResult GetHoursPerMonth(int userId)
        {
            return Ok(_activityService.GetHoursPerMonth(userId));
        }

        [HttpGet("completed/{userId}")]
        public ActionResult GetCompleted(int userId)
        {
            return Ok(_activityService.GetCompleted(userId));
        }

    }
}
