using System.Collections.Generic;
using HaloEzAPI.Abstraction.Enum;

namespace HaloEzAPI.Model.Response.Stats
{
    public class CampaignPostGameReport : MatchDetails
    {
        public IEnumerable<CampaignPlayerStat> PlayerStats { get; set; } 
        public string TotalMissionPlaythroughTime { get; set; }
        public Difficulty Difficulty { get; set; }
        public int[] Skulls { get; set; }
        public bool MissionCompleted { get; set; }
    }
}