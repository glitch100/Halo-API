using System;
using HaloEzAPI.Abstraction.Enum.Halo5;
using HaloEzAPI.Converter;
using Newtonsoft.Json;

namespace HaloEzAPI.Model.Response.Stats.Halo5.Events
{
    public abstract class GameEvent
    {
        public EventType EventName { get; set; }
        [JsonConverter(typeof(TimeSpanConverter))]
        public TimeSpan TimeSinceStart { get; set; }
    }
}