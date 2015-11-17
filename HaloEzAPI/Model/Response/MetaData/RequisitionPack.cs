using System;
using HaloEzAPI.Abstraction.Enum;
using HaloEzAPI.Abstraction.Interfaces;

namespace HaloEzAPI.Model.Response.MetaData
{
    public class RequisitionPack : IGuidContentIds, IDetail
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string LargeImageUrl { get; set; }
        public string MediumImageUrl { get; set; }
        public string SmallImageUrl { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsNew { get; set; }
        public int CreditPrice { get; set; }
        public bool IsPurchasableWithCredits { get; set; }
        public bool IsPurchasableFromMarketplace { get; set; }
        public Guid? XboxMarketplaceProductId { get; set; }
        public int MerchandisingOrder { get; set; }
        public Flair? Flair { get; set; }
        public Guid Id { get; set; }
        public Guid ContentId { get; set; }
    }
}