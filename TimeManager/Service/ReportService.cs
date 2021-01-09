using AutoMapper;
using System.Collections.Generic;
using TimeManager.DTO;

namespace TimeManager.Service
{
    public class ReportService
    {
        private readonly IMapper _mapper;
        ActivityService _activityService;

        public ReportService(ActivityService activityService, IMapper mapper)
        {
            _activityService = activityService;
            _mapper = mapper;
        }

        public ReportDTO GetTotalCompletedHours(int userId)
        {
            var activities = _activityService.GetAll(userId);

            var report = new ReportDTO();

            activities.ForEach(a => report.TotalCompletedHours += a.CompletedHours);

            return report;
        }

        public List<OnGoingActivityDTO> GetOngoingActivities(int userId)
        {
            var activities = _activityService.GetOngoing(userId);
            var dto = new List<OnGoingActivityDTO>();
            activities.ForEach(a => dto.Add(_mapper.Map<OnGoingActivityDTO>(a)));

            return dto;
        }

        public int GetTotalCompletedActivities(int userId)
        {
            return _activityService.GetTotalCompleted(userId);
        }
    }
}