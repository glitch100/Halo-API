using System;

namespace HaloEzAPI.Model.Response.Stats.Halo5.Campaign
{
    public class CampaignMissionStat
    {
        public FlexibleStats FlexibleStats { get; set; }
        public CampaignRunThroughStats CoopStats { get; set; }
        public CampaignRunThroughStats SoloStats { get; set; }
        public Guid MissionId { get; set; }
    }
}