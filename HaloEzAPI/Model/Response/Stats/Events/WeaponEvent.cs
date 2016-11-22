using System.Collections.Generic;

namespace HaloEzAPI.Model.Response.Stats.Events
{
    public class WeaponEvent : PlayerEvent
    {
        public IEnumerable<uint> WeaponAttachmentIds { get; set; }
        public uint WeaponStockId { get; set; }
    }
}