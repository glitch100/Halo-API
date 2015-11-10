using System.Collections.Generic;

namespace HaloEzAPI.Model.Response.Stats
{
    public class WarzoneServiceRecordQueryResponse
    {
        public IEnumerable<ServiceRecordResult<WarzoneServiceRecord>> Results { get; set; }  
    }
}