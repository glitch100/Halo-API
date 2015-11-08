using System.Collections.Generic;

namespace HaloEzAPI.Model.Response
{
    public class CampaignStat : PlayerMatchBreakdown
    {
        public IEnumerable<CampaignMissionStat> CampaignMissionStats { get; set; }
    }
}