using Newtonsoft.Json;
using System;
using TimeManager.Converters;

namespace TimeManager.DTO
{
    public class HoursDTO
    {
        public int Id { get; set; }

        [JsonConverter(typeof(TimeConverter))]
        public TimeSpan Time { get; set; }
    }
}
