using HaloEzAPI.Model.Response.MetaData.HaloWars2.Views;

namespace HaloEzAPI.Model.Response.MetaData.HaloWars2.Cards
{
    public class HW2LeaderPower
    {
        public string ObjectTypeId { get; set; }
        public HW2ApiItem<HW2LeaderPowerInnerViewDisplayInfo> DisplayInfo { get; set; }
        public ImageView Image { get; set; }
    }
}