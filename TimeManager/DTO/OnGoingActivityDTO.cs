using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeManager.DTO
{
    public class OnGoingActivityDTO
    {
        public string Name { get; set; }
        public TimeSpan EstimatedHours { get; set; }
        public TimeSpan CompletedHours { get; set; }
    }
}
