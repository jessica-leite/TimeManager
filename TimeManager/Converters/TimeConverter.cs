using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TimeManager.Converters
{
    public class TimeConverter : JsonConverter<TimeSpan>
    {
        public override TimeSpan Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var test = reader.GetString();
            var time = test.Split(":");

            return new TimeSpan(int.Parse(time[0]), int.Parse(time[1]), 0);
        }

        public override void Write(Utf8JsonWriter writer, TimeSpan value, JsonSerializerOptions options)
        {
            writer.WriteStringValue($"{value.Hours}:{value.Minutes}");
        }
    }
}
