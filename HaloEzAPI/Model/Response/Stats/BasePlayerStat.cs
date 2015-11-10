using System.Collections.Generic;

namespace HaloEzAPI.Model.Response.Stats
{
    public class BasePlayerStat : PlayerMatchBreakdown
    {
        public IEnumerable<KillDetail> KilledOpponentDetails { get; set; }
        public IEnumerable<KillDetail> KilledByOpponentDetails { get; set; }
        public FlexibleStats FlexibleStats { get; set; }
        public CreditsEarned CreditsEarned { get; set; }
        public IEnumerable<MetaCommendationDelta> MetaCommendationDeltas { get; set; }
        public IEnumerable<ProgressiveCommendationDelta> ProgressiveCommendationDeltas { get; set; }
        public Player Player { get; set; }
        public int TeamId { get; set; }
        public int Rank { get; set; }
        public bool DNF { get; set; }
        public string AvgLifeTimeOfPlayer { get; set; }
        public bool IsTeamGame { get; set; }
    }
}