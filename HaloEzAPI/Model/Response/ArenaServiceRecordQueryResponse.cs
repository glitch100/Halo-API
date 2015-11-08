using System.Collections.Generic;

namespace HaloEzAPI.Model.Response
{
    public class ArenaServiceRecordQueryResponse
    {
        public IEnumerable<ServiceRecordResult<ArenaServiceRecord>> Results { get; set; } 
    }
}