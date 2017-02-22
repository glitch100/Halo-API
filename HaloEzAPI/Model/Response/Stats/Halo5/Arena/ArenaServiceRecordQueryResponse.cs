using System.Collections.Generic;

namespace HaloEzAPI.Model.Response.Stats.Halo5.Arena
{
    public class ArenaServiceRecordQueryResponse
    {
        public IEnumerable<ServiceRecordResult<ArenaServiceRecord>> Results { get; set; } 
    }
}