using System;
using TimeManager.DTO;

namespace TimeManager.Service
{
    public class ReportService
    {
        ActivityService _activityService;

        public ReportService(ActivityService activityService)
        {
            _activityService = activityService;
        }

        public ReportDTO GetTotalCompletedHours()
        {
            var activities = _activityService.GetAll();

            var report = new ReportDTO();

            activities.ForEach(a => report.TotalCompletedHours += a.CompletedHours);

            return report;
        }
    }
}
