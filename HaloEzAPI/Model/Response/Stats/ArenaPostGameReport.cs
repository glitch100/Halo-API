using System;
using System.Collections.Generic;

namespace HaloEzAPI.Model.Response.Stats
{
    public class ArenaPostGameReport : MatchDetails
    {
        public IEnumerable<ArenaPlayerStat> PlayerStats { get; set; }
        public Guid SeasonId { get; set; }
        public IEnumerable<TeamStat> TeamStats { get; set; } 
    }
}