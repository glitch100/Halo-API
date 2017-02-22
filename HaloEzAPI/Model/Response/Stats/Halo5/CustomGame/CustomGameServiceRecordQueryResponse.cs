using System.Collections.Generic;

namespace HaloEzAPI.Model.Response.Stats.Halo5.CustomGame
{
    public class CustomGameServiceRecordQueryResponse
    {
        public IEnumerable<ServiceRecordResult<CustomGameServiceRecord>> Results { get; set; } 
    }
}