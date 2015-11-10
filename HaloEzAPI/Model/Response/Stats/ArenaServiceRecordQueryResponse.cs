using System.Collections.Generic;

namespace HaloEzAPI.Model.Response.Stats
{
    public class ArenaServiceRecordQueryResponse
    {
        public IEnumerable<ServiceRecordResult<ArenaServiceRecord>> Results { get; set; } 
    }
}