using System;

namespace HaloEzAPI.Model.Response.Stats.Halo5
{
    public class TopGameBaseVariant
    {
        public int GameBaseVariant { get; set; }
        public int NumberOfMatchesCompleted { get; set; }
        public Guid GameBaseVariantId { get; set; }
        public int NumberOfMatchesWon { get; set; }
    }
}