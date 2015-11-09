using System.Collections.Generic;

namespace HaloEzAPI.Model.Response
{
    public class CustomGameServiceRecordQueryResponse
    {
        public IEnumerable<ServiceRecordResult<CustomGameServiceRecord>> Results { get; set; } 
        
    }
}