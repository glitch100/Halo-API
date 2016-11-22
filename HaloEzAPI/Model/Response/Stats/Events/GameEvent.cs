using System;
using HaloEzAPI.Abstraction.Enum;
using HaloEzAPI.Converter;
using Newtonsoft.Json;

namespace HaloEzAPI.Model.Response.Stats.Events
{
    public abstract class GameEvent
    {
        public EventType EventName { get; set; }
        [JsonConverter(typeof(TimeSpanConverter))]
        public TimeSpan TimeSinceStart { get; set; }
    }
}