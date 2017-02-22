using System.Collections.Generic;
using HaloEzAPI.Model.Response.MetaData.HaloWars2.Shared;

namespace HaloEzAPI.Model.Response.MetaData.HaloWars2.Campaign
{
    public class CampaignLevels
    {
        public Paging Paging { get; set; }
        public IEnumerable<ContentItem> ContentItems { get; set; }
    }
}
