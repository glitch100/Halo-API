using System.Collections.Generic;
using HaloEzAPI.Converter;
using HaloEzAPI.Model.Response.Stats.Events;
using Newtonsoft.Json;

namespace HaloEzAPI.Model.Response.Stats
{
    public class MatchEvent
    {
        [JsonConverter(typeof(MatchEventConverter))]
        public IEnumerable<GameEvent> GameEvents { get; set; }
        /// <summary>
        /// Experimental API so this boolean determines whether the returned events aren't full, or don't match up to expectations
        /// </summary>
        public bool IsCompletedSetOfEvents { get; set; }
    }
}