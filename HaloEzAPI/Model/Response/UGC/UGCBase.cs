using HaloEzAPI.Abstraction.Enum;
using HaloEzAPI.Model.Response.Stats;

namespace HaloEzAPI.Model.Response.UGC
{
    public class UGCBase
    {
        public Variant BaseMap { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public AccessControl AccessControl { get; set; }
        public TimeUtc CreationTimeUtc { get; set; }
        public TimeUtc LastModifiedDateUtc { get; set; }
        public bool Banned { get; set; }
        public Variant Identity { get; set; }
        public UGCStats Stats { get; set; }
    }
}