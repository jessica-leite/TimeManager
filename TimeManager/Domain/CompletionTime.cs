using System;

namespace TimeManager.Domain
{
    public class CompletionTime
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public int ActivityId { get; set; }
        public Activity Activity { get; set; }
    }
}