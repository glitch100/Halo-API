using System.Collections.Generic;

namespace HaloEzAPI.Model.Response.Stats
{
    public class CampaignServiceRecordQueryResponse
    {
        public IEnumerable<ServiceRecordResult<CampaignServiceRecord>> Results { get; set; } 
    }
}