﻿using AutoMapper;
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

        public void Add(ActivityDTO activity)
        {
            //TODO implement cookies to get current user
            var activityModel = _mapper.Map<Activity>(activity);
            activityModel.UserId = 3;

            _context.Activity.Add(activityModel);
            _context.SaveChanges();

            activity.Id = activityModel.Id;
        }

        public ActivityDTO GetById(int id)
        {
            var activityModel = _context.Activity.Find(id);

            return _mapper.Map<ActivityDTO>(activityModel);
        }

        public List<ActivityDTO> GetAll()
        {
            var activities = _context.Activity.ToList();

            var activitiesDTO = new List<ActivityDTO>();
            activities.ForEach(a => activitiesDTO.Add(_mapper.Map<ActivityDTO>(a)));

            return activitiesDTO;
        }

        public void Update(ActivityDTO activity)
        {
            //TODO alterar atribuição de UserId
            var activityModel = _mapper.Map<Activity>(activity);
            activityModel.UserId = 3;
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
