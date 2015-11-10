using System;
using System.Collections.Generic;

namespace HaloEzAPI.Model.Response.Stats
{
    public class ArenaStats : PlayerMatchBreakdown
    {
        public IEnumerable<ArenaPlaylistStat> ArenaPlaylistStats { get; set; }
        public CSR HighestCsrAttained { get; set; }
        public IEnumerable<GameBaseVariantStat> ArenaGameBaseVariantStats { get; set; }
        public IEnumerable<TopGameBaseVariant> TopGameBaseVariants { get; set; }
        public Guid? HighestCsrPlaylistId { get; set; }
    }
}