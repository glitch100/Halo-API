using System;
using Newtonsoft.Json;

namespace HaloEzAPI.Model.Response
{
    public class MatchDetails
    {
        public Guid MapId { get; set; }
        public Variant MapVariant { get; set; }
        public Guid GameBaseVariantId { get; set; }
        public Variant GameVariant { get; set; }
        public bool IsTeamGame { get; set; }
        [JsonConverter(typeof(Converter.TimeSpanConverter))]
        public TimeSpan MatchDuration { get; set; }
    }
}