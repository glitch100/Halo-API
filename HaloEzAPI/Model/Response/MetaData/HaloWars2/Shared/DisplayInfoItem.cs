using HaloEzAPI.Model.Response.MetaData.HaloWars2.Views;

namespace HaloEzAPI.Model.Response.MetaData.HaloWars2.Shared
{
    public class DisplayInfoItem : HW2ApiItem<DisplayInfoView>
    {
        public string MarketplaceProductId { get; set; }
        public string UWProductId { get; set; }
    }
}