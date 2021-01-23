using AutoMapper;
using AutoMapper.Internal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TimeManager.Domain;
using TimeManager.Domain.Context;
using TimeManager.DTO;

namespace TimeManager.Service
{
    public class ActivityService
    {
        private readonly TimeManagerContext _context;
        private readonly IMapper _mapper;

        public ActivityService(TimeManagerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Add(ActivityDTO activity, int userId)
        {
            var activityModel = _mapper.Map<Activity>(activity);
            activityModel.UserId = userId;

            _context.Activity.Add(activityModel);
            _context.SaveChanges();

            activity.Id = activityModel.Id;

            if (activity.CompletedHours.TotalHours > 0)
            {
                var item = new ActivityItem();
                item.ActivityId = activityModel.Id;
                item.End = DateTime.Now;
                item.Start = item.End - activity.CompletedHours;

                _context.ActivityItem.Add(item);
                _context.SaveChanges();
            }
        }

        public int GetTotalCompleted(int userId)
        {
            return _context.Activity
                .Where(a => a.IsCompleted)
                .Count();
        }

        public List<Activity> GetCompleted(int userId)
        {
            return _context.Activity
                .Where(a => a.UserId == userId && a.IsCompleted)
                .ToList();
        }

        public void AddHours(HoursDTO hours)
        {
            var now = DateTime.Now;
            _context.ActivityItem.Add(new ActivityItem
            {
                ActivityId = hours.Id,
                End = now,
                Start = now - hours.Time
            });

            _context.SaveChanges();
        }

        public TimeSpan GetHoursPerMonth(int userId)
        {
            var activityItems = _context.ActivityItem
                .Where(a => a.End.Month == DateTime.Now.Month)
                .Include(a => a.Activity)
                .Where(a => a.Activity.UserId == userId)
                .ToList();

            var completedHours = new TimeSpan();
            activityItems.ForEach(a => completedHours += a.End - a.Start);

            return completedHours;
        }

        public List<Activity> GetOngoing(int userId)
        {
            return _context.Activity
                .Where(a => a.UserId == userId && !a.IsCompleted)
                .ToList();
        }

        public TimeSpan GetHoursPerWeek(int userId)
        {
            var today = DateTime.Now;
            var days = today.DayOfWeek - DayOfWeek.Monday;
            var mondayDay = today.Day - days;
            var monday = new DateTime(today.Year, today.Month, mondayDay);

            var dayOfWeek = DateTime.Now.DayOfWeek;
            var activityItems = _context.ActivityItem
                .Where(a => a.End >= monday)
                .Include(a => a.Activity)
                .Where(a => a.Activity.UserId == userId)
                .ToList();

            var completedHours = new TimeSpan();
            activityItems.ForEach(a => completedHours += a.End - a.Start);

            return completedHours;
        }

        public ActivityDTO GetById(int id)
        {
            var activityModel = _context.Activity.Find(id);

            return _mapper.Map<ActivityDTO>(activityModel);
        }

        public List<ActivityDTO> GetAll(int userId)
        {
            var activities = _context.Activity
                .Where(a => a.UserId == userId && !a.IsCompleted)
               .Include(a => a.ActivityItems)
                .ToList();

            var activitiesDTO = new List<ActivityDTO>();
            activities.ForEach(a =>
            {
                var activity = _mapper.Map<ActivityDTO>(a);

                if (a.ActivityItems.Any())
                {
                    a.ActivityItems.ForAll(a => activity.CompletedHours += a.End - a.Start);
                }

                var remainingTime = activity.EstimatedHours - activity.CompletedHours;
                activity.RemainingTime = remainingTime > TimeSpan.Zero ? remainingTime : TimeSpan.Zero;

                activitiesDTO.Add(activity);

            });
            return activitiesDTO;
        }

        public void Update(ActivityDTO activity, int userId)
        {
            var activityModel = _mapper.Map<Activity>(activity);
            activityModel.UserId = userId;
            _context.Activity.Update(activityModel);
            _context.SaveChanges();
        }

        public void Remove(int id)
        {
            _context.Remove(new Activity { Id = id });
            _context.SaveChanges();
        }
    }
}