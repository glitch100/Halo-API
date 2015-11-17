using System;
using System.Collections.Generic;
using HaloEzAPI.Abstraction.Enum;
using HaloEzAPI.Abstraction.Interfaces;

namespace HaloEzAPI.Model.Response.MetaData
{
    public class Requisition : IGuidContentIds, IDetail
    {
        public IEnumerable<GameMode> GameModes { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public RarityType RarityType { get; set; }
        public string Rarity { get; set; }
        public bool IsMythic { get; set; }
        public bool IsCertification { get; set; }
        public bool IsWearable { get; set; }
        public ReqUseType UseType { get; set; }
        public string LargeImageUrl { get; set; }
        public string MediumImageUrl { get; set; }
        public string SmallImageUrl { get; set; }
        public string CategoryName { get; set; }
        public string InternalCategoryName { get; set; }
        public string SubcategoryName { get; set; }
        public int SubcategoryOrder { get; set; }
        public int CreditsAwarded { get; set; }
        public Guid Id { get; set; }
        public Guid ContentId { get; set; }
    }
}