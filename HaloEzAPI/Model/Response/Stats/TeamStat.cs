using System.Collections.Generic;

namespace HaloEzAPI.Model.Response.Stats
{
    public class TeamStat
    {
        public int TeamId { get; set; }
        public int Score { get; set; }
        public int Rank { get; set; }
        public IEnumerable<RoundStat> RoundStats { get; set; } 
    }
}