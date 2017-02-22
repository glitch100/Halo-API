using System;

namespace HaloEzAPI.Model.Response.Stats.Halo5
{
    public class ProgressiveCommendationDelta
    {
        public Guid Id { get; set; }
        public int PreviousPrOgress { get; set; }
        public int Progress { get; set; }
    }
}