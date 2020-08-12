using Newtonsoft.Json;
using System;
using TimeManager.Converters;

namespace TimeManager.DTO
{
    public class ActivityDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }

        [JsonConverter(typeof(TimeConverter))]
        public TimeSpan EstimatedHours { get; set; }

        [JsonConverter(typeof(TimeConverter))]
        public TimeSpan CompletedHours { get; set; }
    }
}
