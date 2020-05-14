using System.Collections.Generic;
using HaloEzAPI.Model.Response.MetaData.HaloWars2.Shared;
using HaloEzAPI.Model.Response.MetaData.HaloWars2.Views;

namespace HaloEzAPI.Model.Response.MetaData.HaloWars2.Cards
{
    public class HW2StartingArmyOptionsView : HW2ApiItem<HW2StartingArmyDisplayInfoView>
    {
        public List<IdentityMetaData> Cards { get; set; }
        public HW2StartingArmyDisplayInfoView HW2StartingArmy { get; set; }
    }
}