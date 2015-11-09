using System.Collections.Generic;

namespace HaloEzAPI.Model.Response
{
    public class CustomGameStat : PlayerMatchBreakdown
    {
        public IEnumerable<GameBaseVariantStat> CustomGameBaseVariantStats { get; set; }
        public IEnumerable<TopGameBaseVariant> TopGameBaseVariants { get; set; }
    }
}