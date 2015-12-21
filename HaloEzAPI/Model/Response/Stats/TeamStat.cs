using System;
using System.Collections.Generic;
using HaloEzAPI.Converter;
using Newtonsoft.Json;

namespace HaloEzAPI.Model.Response.Stats
{
    public class TeamStat
    {
        public int TeamId { get; set; }
        [JsonConverter(typeof(ScoreConverter))]
        public int Score { get; set; }
        public int Rank { get; set; }
        public IEnumerable<RoundStat> RoundStats { get; set; } 
    }
}