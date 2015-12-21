using System;
using HaloEzAPI.Converter;
using Newtonsoft.Json;

namespace HaloEzAPI.Model.Response.Stats
{
    public class StatTimelapse
    {
        public Guid Id { get; set; }
        [JsonIgnore]
        [JsonConverter(typeof(TimeSpanConverter))]
        public TimeSpan Timelapse { get; set; }
    }
}