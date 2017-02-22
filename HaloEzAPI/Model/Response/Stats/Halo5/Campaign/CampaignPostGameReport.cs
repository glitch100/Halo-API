using System.Collections.Generic;
using HaloEzAPI.Abstraction.Enum.Halo5;

namespace HaloEzAPI.Model.Response.Stats.Halo5.Campaign
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