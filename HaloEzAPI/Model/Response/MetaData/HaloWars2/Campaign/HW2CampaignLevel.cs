using System.Collections.Generic;
using HaloEzAPI.Model.Response.MetaData.HaloWars2.Cards;
using HaloEzAPI.Model.Response.MetaData.HaloWars2.Shared;
using HaloEzAPI.Model.Response.MetaData.HaloWars2.Views;

namespace HaloEzAPI.Model.Response.MetaData.HaloWars2.Campaign
{
    public class HW2CampaignLevel
    {
        public int Id { get; set; }
        public int MaxScore { get; set; }
        public IEnumerable<ObjectiveItem> CriticalObjectives { get; set; } 
        public IEnumerable<ObjectiveItem> BonusObjectives { get; set; } 
        public IEnumerable<ObjectiveItem> OptionalObjectives { get; set; }
        public IEnumerable<SkullItem> Skulls { get; set; }
        public IEnumerable<AwardedPackItem> AwardedPacks { get; set; }
        public DisplayInfoItem<DisplayInfoView> DisplayInfo { get; set; }
    }
}