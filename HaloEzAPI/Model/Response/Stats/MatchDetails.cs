using System;
using HaloEzAPI.Converter;
using Newtonsoft.Json;

namespace HaloEzAPI.Model.Response.Stats
{
    public class MatchDetails
    {
        public Guid MapId { get; set; }
        public Variant MapVariant { get; set; }
        public Guid GameBaseVariantId { get; set; }
        public Variant GameVariant { get; set; }
        public bool IsTeamGame { get; set; }
        [JsonConverter(typeof(TimeSpanConverter))]
        public TimeSpan MatchDuration { get; set; }
        [JsonConverter(typeof(TimeSpanConverter))]
        public TimeSpan TotalDuration { get; set; }
        public Guid MapVariantId { get; set; }
        public Guid GameVariantId { get; set; }
        public Guid PlaylistId { get; set; }
        public bool IsMatchOver { get; set; }
    }
}