using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HaloEzAPI.Model.Response
{
    public class Match
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
        public Guid HopperId { get; set; }
        
        /// <summary>
        /// The ID of the base map for this match. Maps are available via the Metadata API.
        /// </summary>
        public Guid MapId { get; set; }

        public Variant MapVariant { get; set; }

        /// <summary>
        /// The ID of the game base variant for this match. Game base variants are available
        /// via the Metadata API.
        /// </summary>
        public Guid GameBaseVariantId { get; set; }

        public Variant GameVariant { get; set; }

        [JsonConverter(typeof(TimeSpanConverter))]
        public TimeSpan MatchDuration { get; set; }

        public MatchCompletedDate ISO8601Date { get; set; }

        public IEnumerable<Team> Teams { get; set; }
        public IEnumerable<MatchPlayer> Players { get; set; }
        public bool IsTeamGame { get; set; }
    }
}
