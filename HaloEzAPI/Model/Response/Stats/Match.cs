using System;
using System.Collections.Generic;

namespace HaloEzAPI.Model.Response.Stats
{
    public class Match : MatchDetails
    {
        /// <summary>
        /// The ID for this match. More match details are available via the applicable
        /// Post Game Carnage Report endpoint.
        /// </summary>
        public Id Id { get; set; }

        /// <summary>
        /// The ID of the playlist (aka "Hopper") for the match. 
        /// Hoppers are used in Arena and Warzone. In Arena, they function just as you would
        /// expect, similar to previous Halo titles. Warzone uses hoppers as well. There
        /// will be multiple Warzone hoppers which contain a rotating playlist of scenarios
        /// to play. 
        /// Null for campaign & custom games. 
        /// Playlists are available via the Metadata API.
        /// </summary>
        /// 
        public Guid? HopperId { get; set; }
        public Link Links { get; set; } 
        public MatchCompletedDate MatchCompletedDate { get; set; }
        public IEnumerable<Team> Teams { get; set; }
        public IEnumerable<MatchPlayer> Players { get; set; }
        public bool IsTeamGame { get; set; }
        public string SeasonId { get; set; }
    }
}
