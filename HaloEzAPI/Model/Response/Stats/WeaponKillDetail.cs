using System;
using HaloEzAPI.Converter;
using Newtonsoft.Json;

namespace HaloEzAPI.Model.Response.Stats
{
    public class WeaponKillDetail
    {
        public WeaponId WeaponId { get; set; }
        public int TotalKills { get; set; }
        public int TotalHeadshots { get; set; }
        public double TotalDamageDealt { get; set; }
        public int TotalShotsFired { get; set; }
        public int TotalShotsLanded { get; set; }
        [JsonConverter(typeof(TimeSpanConverter))]
        public TimeSpan TotalPossessionTime { get; set; }
    }
}