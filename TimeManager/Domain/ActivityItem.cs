using System;

namespace TimeManager.Domain
{
    public class ActivityItem
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public int ActivityId { get; set; }
        public Activity Activity { get; set; }
    }
}