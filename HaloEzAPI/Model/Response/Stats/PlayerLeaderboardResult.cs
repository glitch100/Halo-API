using System.Collections.Generic;

namespace HaloEzAPI.Model.Response.Stats
{
    public class PlayerLeaderboardResults
    {
        public IEnumerable<PlayerResult> Results { get; set; }
        public int Start { get; set; }
        public int Count { get; set; }
        public int ResultCount { get; set; }
        public int TotalCount { get; set; }
    }
}