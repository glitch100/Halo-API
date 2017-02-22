using HaloEzAPI.Abstraction.Enum.Halo5;

namespace HaloEzAPI.Model.Response.Stats.Halo5
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