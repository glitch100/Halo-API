using System;
using System.Collections.Generic;

namespace HaloEzAPI.Model.Response.MetaData
{
    public class Reward
    {
        public int XP { get; set; }
        public IEnumerable<RequisitionPack> RequisitionPacks { get; set; }
        public Guid Id { get; set; }
        public Guid ContentId { get; set; }
    }
}