using HaloEzAPI.Abstraction.Enum;

namespace HaloEzAPI.Model.Response.Stats
{
    public class MatchPlayer
    {
        public Player Player { get; set; }
        public int TeamId { get; set; }
        // The player's team-agnostic ranking in this match.
        public int Rank { get; set; }
        public PlayerMatchResult Result { get; set; }
        public int TotalKills { get; set; }
        public int TotalDeaths { get; set; }
        public int TotalAssists { get; set; }
    }
}