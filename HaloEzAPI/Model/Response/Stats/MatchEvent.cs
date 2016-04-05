using System.Collections.Generic;

namespace HaloEzAPI.Model.Response.Stats
{
    public class MatchEvent
    {
        public IEnumerable<Event> GameEvents { get; set; }
        /// <summary>
        /// Experimental API so this boolean determines whether the returned events aren't full, or don't match up to expectations
        /// </summary>
        public bool IsCompletedSetOfEvents { get; set; }
    }
}