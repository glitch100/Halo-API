using System.Collections.Generic;
using HaloEzAPI.Abstraction.Enum.Halo5;

namespace HaloEzAPI.Model.Response.Stats.Halo5.Events
{
    public class DeathEvent : GameEvent
    {
        public IEnumerable<Player> Assistants { get; set; }
        public DeathDiposition DeathDiposition { get; set; }
        public bool IsAssassination { get; set; }
        public bool IsGroundPound { get; set; }
        public bool IsHeadshot { get; set; }
        public bool IsMelee { get; set; }
        public bool IsShoulderBash { get; set; }
        public bool IsWeapon { get; set; }
        public uint? ImpulseId { get; set; }
        public Player Killer { get; set; }
        public KillerAgent KillerAgent { get; set; }
        public IEnumerable<uint> KillerWeaponAttachmentIds { get; set; }
        public uint KillerWeaponStockId { get; set; }
        public WorldLocation KillerWorldLocation { get; set; }
        public Player Victim { get; set; }
        public IEnumerable<uint> VictimAttachmentIds { get; set; }
        public uint VictimStockId { get; set; }
        public WorldLocation VictimWorldLocation { get; set; }
    }
}