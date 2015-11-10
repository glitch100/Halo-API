using System;
using HaloEzAPI.Abstraction.Enum;

namespace HaloEzAPI.Model.Response.Stats
{
    public class RewardSetObject
    {
        public Guid RewardSet { get; set; }
        public RewardSourceType RewardSourceType { get; set; }
        public int? SpartanRankSource { get; set; }
        public Guid? CommendationLevelId { get; set; }
        public Guid? CommendationSource { get; set; }
    }
}