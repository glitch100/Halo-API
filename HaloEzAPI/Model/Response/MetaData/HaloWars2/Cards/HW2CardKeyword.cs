using HaloEzAPI.Model.Response.MetaData.HaloWars2.Shared;
using HaloEzAPI.Model.Response.MetaData.HaloWars2.Views;

namespace HaloEzAPI.Model.Response.MetaData.HaloWars2.Cards
{
    public class HW2CardKeyword
    {
        public string Keyword { get; set; }
        public DisplayInfoItem<DisplayInfoView> DisplayInfo { get; set; }
    }
}