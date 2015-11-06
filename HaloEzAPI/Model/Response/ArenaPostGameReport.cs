using System;
using System.Collections.Generic;

namespace HaloEzAPI.Model.Response
{
    public class ArenaPostGameReport : MatchDetails
    {
        public IEnumerable<PlayerStat> PlayerStats { get; set; }
        public bool IsMatchOver { get; set; }
        public Guid PlaylistId { get; set; }
        public Guid SeasonId { get; set; }
        public IEnumerable<TeamStat> TeamStats { get; set; } 
    }
}