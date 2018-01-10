using System.Collections.Generic;
using HaloEzAPI.Abstraction.Enum.HaloWars2;
using HaloEzAPI.Model.Response.MetaData.HaloWars2.Shared;
using HaloEzAPI.Model.Response.MetaData.HaloWars2.Views;

namespace HaloEzAPI.Model.Response.MetaData.HaloWars2.Cards
{
    public class HW2Object
    {
        public string ObjectTypeId { get; set; }
        public HW2ObjectDisplayInfo DisplayInfo { get; set; }
        public List<IdentityMetaData> Categories { get; set; }
        public ImageView Image { get; set; }
        // Supply cost required to build this Game Object
        public int StandardSupplyCost { get; set; }
        // Population cost required to build this Game Object.
        public int StandardPopulationCost { get; set; }
        // Energy cost required to build this Game Object.
        public int StandardEnergyCost { get; set; }
        public EffectivenessAgainstGameObject EffectivenessAgainstInfantry { get; set; }
        public EffectivenessAgainstGameObject EffectivenessAgainstVehicles { get; set; }
        public EffectivenessAgainstGameObject EffectivenessAgainstAir { get; set; }
    }
}