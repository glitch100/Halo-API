using System;

namespace HaloEzAPI.Model.Response
{
    public class ProgressiveCommendationDelta
    {
        public Guid Id { get; set; }
        public int PreviousPorgress { get; set; }
        public int Progress { get; set; }
    }
}