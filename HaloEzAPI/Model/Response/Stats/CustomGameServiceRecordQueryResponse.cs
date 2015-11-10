using System.Collections.Generic;

namespace HaloEzAPI.Model.Response.Stats
{
    public class CustomGameServiceRecordQueryResponse
    {
        public IEnumerable<ServiceRecordResult<CustomGameServiceRecord>> Results { get; set; } 
    }
}