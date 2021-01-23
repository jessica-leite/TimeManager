using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TimeManager.Domain.Context;
using TimeManager.DTO;

namespace TimeManager.Service
{
    public class ReportService
    {
        private readonly IMapper _mapper;
        ActivityService _activityService;
        private readonly TimeManagerContext _context;


        public ReportService(ActivityService activityService, IMapper mapper, TimeManagerContext context)
        {
            _activityService = activityService;
            _mapper = mapper;
            _context = context;
        }

        public ReportDTO GetTotalCompletedHours(int userId)
        {
            var activityItems = _context.ActivityItem
                .Include(a => a.Activity)
                .Where(i => i.Activity.UserId == userId)
                .Select(x => x.End - x.Start)
                .ToList();

            var report = new ReportDTO();
            activityItems.ForEach(a => { report.TotalCompletedHours += a; });

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