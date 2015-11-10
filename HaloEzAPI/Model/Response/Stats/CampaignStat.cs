using System.Collections.Generic;

namespace HaloEzAPI.Model.Response.Stats
{
    public class CampaignStat : PlayerMatchBreakdown
    {
        public IEnumerable<CampaignMissionStat> CampaignMissionStats { get; set; }
    }
}