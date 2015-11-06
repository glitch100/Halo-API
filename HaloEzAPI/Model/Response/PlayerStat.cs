using System;
using System.Collections.Generic;

namespace HaloEzAPI.Model.Response
{
    public class PlayerStat : PlayerMatchBreakdown
    {
        public XpInfo XpInfo { get; set; }
        public CSR PreviousCsr { get; set; }
        public CSR CurrentCsr { get; set; }
        public int MeasurementMatchesLeft { get; set; }
        public IEnumerable<RewardSetObject> RewardSets { get; set; }
        public IEnumerable<KillDetail> KilledOpponentDetails { get; set; }
        public IEnumerable<KillDetail> KilledByOpponentDetails { get; set; }
        public FlexibleStats FlexibleStats { get; set; }
        public CreditsEarned CreditsEarned { get; set; }
        public IEnumerable<MetaCommendationDelta> MetaCommendationDeltas { get; set; }
        public ProgressiveCommendationDelta ProgressiveCommendationDeltas { get; set; }
        public Player Player { get; set; }
        public int TeamId { get; set; }
        public int Rank { get; set; }
        public bool DNF { get; set; }
        public string AvgLifeTimeOfPlayer { get; set; }
        public IEnumerable<TeamStat> TeamStats { get; set; }
        public bool IsMatchOver { get; set; }
        public TimeSpan TotalDuration { get; set; }
        public Guid MapVariantId { get; set; }
        public Guid GameVariantId { get; set; }
        public Guid PlaylistId { get; set; }
        public Guid MapId { get; set; }
        public Guid GameBaseVariantId { get; set; }
        public bool IsTeamGame { get; set; }
    }
}