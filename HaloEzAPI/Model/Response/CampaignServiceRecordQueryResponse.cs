using System.Collections.Generic;

namespace HaloEzAPI.Model.Response
{
    public class CampaignServiceRecordQueryResponse
    {
        public IEnumerable<ServiceRecordResult<CampaignServiceRecord>> Results { get; set; } 
    }
}