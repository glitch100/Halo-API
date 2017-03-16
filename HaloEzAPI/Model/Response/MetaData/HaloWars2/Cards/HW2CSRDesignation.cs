using System.Collections.Generic;
using HaloEzAPI.Model.Response.MetaData.HaloWars2.Imaging;
using HaloEzAPI.Model.Response.MetaData.HaloWars2.Shared;

namespace HaloEzAPI.Model.Response.MetaData.HaloWars2.Cards
{
    public class HW2CSRDesignation
    {
        public HW2CSRDisplayInfoItem DisplayInfo { get; set; }
        public int ID { get; set; }
        public Image Image { get; set; }
        public IEnumerable<HW2ApiItem<HW2CSRDesignationTierView>> Tiers { get; set; } 
    }
}