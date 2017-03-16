using System.Collections.Generic;
using HaloEzAPI.Abstraction.Enum.HaloWars2;
using HaloEzAPI.Model.Response.MetaData.HaloWars2.Imaging;
using HaloEzAPI.Model.Response.MetaData.HaloWars2.Shared;

namespace HaloEzAPI.Model.Response.MetaData.HaloWars2.Cards
{
    public class HW2Card
    {
        public Rarity Rarity { get; set; }
        public IdentityMetaData Entitlement { get; set; }
        public bool EntitlementRequired { get; set; }
        public bool ExcludeFromCardGeneration { get; set; }
        public IdentityMetaData Leader { get; set; }
        public ImageItem ForegroundImage { get; set; }
        public HW2CardDisplayInfoItem DisplayInfo { get; set; }
        public IdentityMetaData GameObject { get; set; }
        public int? LastStandNumber { get; set; }
        public int EnergyCost { get; set; }
        public PlayType PlayType { get; set; }
        public IEnumerable<IdentityMetaData> Keywords { get;set; }
    }
}