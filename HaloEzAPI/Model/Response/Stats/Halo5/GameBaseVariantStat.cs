using System;

namespace HaloEzAPI.Model.Response.Stats.Halo5
{
    public class GameBaseVariantStat : PlayerMatchBreakdown
    {
        public FlexibleStats FlexibleStats { get; set; }
        public Guid GameBaseVariantId { get; set; }
    }
}