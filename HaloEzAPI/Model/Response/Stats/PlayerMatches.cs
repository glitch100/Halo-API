using System.Collections.Generic;

namespace HaloEzAPI.Model.Response.Stats
{
    public class PlayerMatches
    {
        public int Start { get; set; }
        public int Count { get; set; }
        public int ResultCount { get; set; }
        public IEnumerable<Match> Results { get; set; }
        public bool IsTeamGame { get; set; }
    }
}