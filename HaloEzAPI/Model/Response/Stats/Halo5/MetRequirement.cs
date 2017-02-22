using System;

namespace HaloEzAPI.Model.Response.Stats.Halo5
{
    [Obsolete("This has been made obsolete. Please check RawGuid instead.", true)]
    public class MetRequirement
    {
        public uint Data1 { get; set; }
        public uint Data2 { get; set; }
        public uint Data3 { get; set; }
        public uint Data4 { get; set; }
    }
}