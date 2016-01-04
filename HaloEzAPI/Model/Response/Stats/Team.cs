using HaloEzAPI.Converter;
using Newtonsoft.Json;

namespace HaloEzAPI.Model.Response.Stats
{
    public class Team
    {
        /// <summary>
        /// The ID for the team. The team's ID dictates the team's color. Team colors
        /// are available via the Metadata API.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The team's score at the end of the match. The way the score is determined is
        /// based off the game base variant being played: 
        /// Breakout = number of rounds won,
        /// CTF = number of flag captures,
        /// Slayer = number of kills,
        /// Strongholds = number of points,
        /// Warzone = number of points
        /// </summary>
        [JsonConverter(typeof(ScoreConverter))]
        public int Score { get; set; }

        //The team's rank at the end of the match.
        public int Rank { get; set; }
    }
}