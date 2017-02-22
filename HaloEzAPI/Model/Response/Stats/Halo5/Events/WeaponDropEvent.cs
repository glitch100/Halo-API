using System;
using HaloEzAPI.Converter;
using Newtonsoft.Json;

namespace HaloEzAPI.Model.Response.Stats.Halo5.Events
{
    public class WeaponDropEvent : WeaponEvent
    {
        public int ShotsFired { get; set; }
        public int ShotsLanded { get; set; }
        [JsonConverter(typeof(TimeSpanConverter))]
        public TimeSpan TimeWeaponActiveAsPrimary { get; set; }
    }
}