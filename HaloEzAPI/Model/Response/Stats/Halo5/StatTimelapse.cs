using System;
using HaloEzAPI.Converter;
using Newtonsoft.Json;

namespace HaloEzAPI.Model.Response.Stats.Halo5
{
    public class StatTimelapse
    {
        public Guid Id { get; set; }
        [JsonConverter(typeof(TimeSpanConverter))]
        public TimeSpan Timelapse { get; set; }
    }
}