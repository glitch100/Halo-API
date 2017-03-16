using HaloEzAPI.Model.Response.MetaData.HaloWars2.Shared;

namespace HaloEzAPI.Model.Response.MetaData.HaloWars2.Views
{
    public class DisplayInfoView : BaseView
    {
        public LockedObject BatchLocalization { get; set; }
        public Localization Localization { get; set; }
    }
}