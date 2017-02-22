using System.Collections.Generic;

namespace HaloEzAPI.Model.Response.Stats.Halo5.Campaign
{
    public class CampaignStat : PlayerMatchBreakdown
    {
        public IEnumerable<CampaignMissionStat> CampaignMissionStats { get; set; }
    }
}