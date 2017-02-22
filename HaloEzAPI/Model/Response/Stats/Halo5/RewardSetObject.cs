using System;
using HaloEzAPI.Abstraction.Enum.Halo5;

namespace HaloEzAPI.Model.Response.Stats.Halo5
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