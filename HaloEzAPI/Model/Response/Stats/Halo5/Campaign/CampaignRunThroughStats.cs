using HaloEzAPI.Abstraction.Enum.Halo5;

namespace HaloEzAPI.Model.Response.Stats.Halo5.Campaign
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