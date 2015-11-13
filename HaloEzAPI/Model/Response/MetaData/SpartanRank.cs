using System;

namespace HaloEzAPI.Model.Response.MetaData
{
    public class SpartanRank
    {
        public int StartXP { get; set; }
        public RankReward Reward { get; set; }
        public uint Id { get; set; }
        public Guid ContentId { get; set; }
    }
}