using System.Collections.Generic;

namespace HaloEzAPI.Model.Response.Stats
{
    public class WarzonePlayerStat : BasePlayerStat
    {
        public XpInfo XpInfo { get; set; }
        public int WarzoneLevel { get; set; }
        public int TotalPiesEarned { get; set; }
        public IEnumerable<RewardSetObject> RewardSets { get; set; }
    }
}