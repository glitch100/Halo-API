using System;

namespace HaloEzAPI.Model.Response.Stats
{
    public class ScenarioStat : PlayerMatchBreakdown
    {
        public int TotalPiesEarned { get; set; }
        public FlexibleStats FlexibleStats { get; set; }
        public Guid MapId { get; set; }
        public Guid GameBaseVariantId { get; set; }
    }
}