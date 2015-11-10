using HaloEzAPI.Abstraction.Enum;

namespace HaloEzAPI.Model.Response.Stats
{
    public class CreditsEarned
    {
        public CreditResult Result { get; set; }
        public int TotalCreditsEarned { get; set; }
        public double SpartanRankModifier { get; set; }
        public int PlayerRankAmount { get; set; }
        public double TimePlayedAmount { get; set; }
        public int BoostAmount { get; set; }
    }
}