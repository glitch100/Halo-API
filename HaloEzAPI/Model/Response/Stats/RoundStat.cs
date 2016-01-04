using HaloEzAPI.Converter;
using Newtonsoft.Json;

namespace HaloEzAPI.Model.Response.Stats
{
    public class RoundStat
    {
        public int RoundNumber { get; set; }
        public int Rank { get; set; }
        [JsonConverter(typeof(ScoreConverter))]
        public int Score { get; set; }
    }
}