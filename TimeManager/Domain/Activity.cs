using System;
using System.Collections.Generic;

namespace TimeManager.Domain
{
    public class Activity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public TimeSpan EstimatedHours { get; set; }
        public IEnumerable<CompletionTime> CompletedHours { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}