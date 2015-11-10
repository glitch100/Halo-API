using HaloEzAPI.Abstraction.Enum;

namespace HaloEzAPI.Model.Response.Stats
{
    public class CampaignRunThroughStats
    {
        public int HighestScore { get; set; }
        public Difficulty Difficulty { get; set; }
        public string FastestCompletionTime { get; set; }
        public int[] Skulls { get; set; }
        public int TotalTimesCompleted { get; set; }
        public bool AllSkullsOn { get; set; }
    }
}