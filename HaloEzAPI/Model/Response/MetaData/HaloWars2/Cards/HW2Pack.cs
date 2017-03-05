using System.Collections.Generic;
using HaloEzAPI.Model.Response.MetaData.HaloWars2.Imaging;
using HaloEzAPI.Model.Response.MetaData.HaloWars2.Shared;

namespace HaloEzAPI.Model.Response.MetaData.HaloWars2.Cards
{
    public class HW2Pack
    {
        public IEnumerable<IdentityMetaData> HW2PackRules { get; set; }
        public ImageItem FrontImageHD { get; set; }
        public ImageItem BackImageHD { get; set; }
        public ImageItem HighlightImageHD { get; set; }
        
        public ImageItem FrontImage4K { get; set; }
        public ImageItem BackImage4K { get; set; }
        public ImageItem HighlightImage4K { get; set; }

        public string StackGroup { get; set; }
        public int InventorySortPriotity { get; set; }
    }
}