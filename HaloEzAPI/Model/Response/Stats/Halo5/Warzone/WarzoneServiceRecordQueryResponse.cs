using System.Collections.Generic;

namespace HaloEzAPI.Model.Response.Stats.Halo5.Warzone
{
    public class WarzoneServiceRecordQueryResponse
    {
        public IEnumerable<ServiceRecordResult<WarzoneServiceRecord>> Results { get; set; }  
    }
}