using System.Collections.Generic;
using HaloEzAPI.Abstraction.Enum.Halo5;
using HaloEzAPI.Abstraction.Enum.HaloWars2;
using HaloEzAPI.Model.Response.MetaData.HaloWars2.Shared;
using HaloEzAPI.Model.Response.MetaData.HaloWars2.Views;

namespace HaloEzAPI.Model.Response.MetaData.HaloWars2.Cards
{
    public class HW2Leader
    {
        public Faction Faction { get; set; }
        public List<HW2StartingArmyOptionsView> StartingArmyOptions { get; set; }
        public LeaderId ID { get; set; }
        public HW2LeaderDisplayInfoView DisplayInfo { get; set; }
        public ImageView Image { get; set; }
        public IdentityMetaData HW2PromotionOffer { get; set; }
    }
}