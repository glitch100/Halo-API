using System.Collections.Generic;
using HaloEzAPI.Abstraction.Enum;

namespace HaloEzAPI.Model.Response
{
    public class ServiceRecordResult<T> where T : BaseServiceRecord
    {
        /// <summary>
        /// Players GamerTag
        /// </summary>
        public string Id { get; set; }

        public ResultCode ResultCode { get; set; }
        public T Result { get; set; }
 
    }
}