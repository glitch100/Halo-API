using System;
using System.Collections.Generic;
using HaloEzAPI.Abstraction.Enum;
using HaloEzAPI.Converter;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HaloEzAPI.Model.Response.Stats
{
    public class Event
    {
        public IEnumerable<Player> Assistants { get; set; }
        public DeathDiposition DeathDiposition { get; set; }
        public bool IsAssassination { get; set; }
        public bool IsGroundPound { get; set; }
        public bool IsHeadshot { get; set; }
        public bool IsMelee { get; set; }
        public bool IsShoulderBash { get; set; }
        public bool IsWeapon { get; set; }
        public Player Killer { get; set; }
        public KillerAgent KillerAgent { get; set; }
        public IEnumerable<int> KillerAttachmentIds { get; set; }
        public uint KillerStockId { get; set; }
        public WorldLocation KillerWorldLocation { get; set; }
        public Player Victim { get; set; }
        public IEnumerable<int> VictimAttachmentIds { get; set; }
        public uint VictimStockId { get; set; }
        public WorldLocation VictimWorldLocation { get; set; }
        public string EventName { get; set; }
        [JsonConverter(typeof(TimeSpanConverter))]
        public TimeSpan TimeSinceStart { get; set; }
    }
}