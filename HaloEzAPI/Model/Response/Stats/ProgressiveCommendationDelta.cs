using System;

namespace HaloEzAPI.Model.Response.Stats
{
    public class ProgressiveCommendationDelta
    {
        public Guid Id { get; set; }
        public int PreviousPrOgress { get; set; }
        public int Progress { get; set; }
    }
}