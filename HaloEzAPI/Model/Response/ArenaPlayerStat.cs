using System.Collections.Generic;

namespace HaloEzAPI.Model.Response
{
    public class ArenaPlayerStat : BasePlayerStat
    {
        public IEnumerable<RewardSetObject> RewardSets { get; set; }
        public XpInfo XpInfo { get; set; }
        public CSR PreviousCsr { get; set; }
        public CSR CurrentCsr { get; set; }
        public int MeasurementMatchesLeft { get; set; }
    }
}