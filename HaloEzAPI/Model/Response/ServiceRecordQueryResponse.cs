using System.Collections.Generic;

namespace HaloEzAPI.Model.Response
{
    public class ServiceRecordQueryResponse
    {
        public IEnumerable<ServiceRecordResult> Results { get; set; } 
    }
}