using System.Collections.Generic;

namespace HaloEzAPI.Model.Response
{
    public class WarzonePostGameReport : MatchDetails
    {
        public IEnumerable<WarzonePlayerStat> PlayerStats { get; set; }
        public IEnumerable<TeamStat> TeamStats { get; set; } 
    }
}