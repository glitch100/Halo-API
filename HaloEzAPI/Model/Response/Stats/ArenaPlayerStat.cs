using System.Collections.Generic;

namespace HaloEzAPI.Model.Response.Stats
{
    public class ArenaPlayerStat : BasePlayerStat
    {
        public IEnumerable<RewardSetObject> RewardSets { get; set; }
        public XpInfo XpInfo { get; set; }
        public CSR PreviousCsr { get; set; }
        public CSR CurrentCsr { get; set; }
        public int MeasurementMatchesLeft { get; set; }
    }

    public class WarzonePlayerStat : BasePlayerStat
    {
        public XpInfo XpInfo { get; set; }
        public int WarzoneLevel { get; set; }
        public int TotalPiesEarned { get; set; }
        public IEnumerable<RewardSetObject> RewardSets { get; set; }
    }
}