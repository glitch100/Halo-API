using System.Collections.Generic;

namespace HaloEzAPI.Model.Response.Stats
{
    public class CustomPostGameReport : MatchDetails
    {
        public IEnumerable<BasePlayerStat> PlayerStats { get; set; }
        public IEnumerable<TeamStat> TeamStats { get; set; }
    }
}