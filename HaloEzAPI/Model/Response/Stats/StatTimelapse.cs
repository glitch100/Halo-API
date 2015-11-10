using System;
using Newtonsoft.Json;

namespace HaloEzAPI.Model.Response.Stats
{
    public class StatTimelapse
    {
        public Guid Id { get; set; }
        [JsonIgnore]
        [JsonConverter(typeof(Converter.JSONTimeSpanConverter))]
        public TimeSpan Timelapse { get; set; }
    }
}