using System;
using System.Collections.Generic;
using HaloEzAPI.Abstraction.Enum.Halo5;
using HaloEzAPI.Converter;
using Newtonsoft.Json;

namespace HaloEzAPI.Model.Response.Stats.Halo5.Events
{
    [Obsolete("Refer to the GameEvent abstract class and it's usages in other events")]
    public class FullEvent
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
        public IEnumerable<uint> KillerWeaponAttachmentIds { get; set; }
        public uint KillerWeaponStockId { get; set; }
        public WorldLocation KillerWorldLocation { get; set; }
        public Player Victim { get; set; }
        public IEnumerable<uint> VictimAttachmentIds { get; set; }
        public uint VictimStockId { get; set; }
        public WorldLocation VictimWorldLocation { get; set; }
        public EventType EventName { get; set; }
        [JsonConverter(typeof(TimeSpanConverter))]
        public TimeSpan TimeSinceStart { get; set; }
    }
}