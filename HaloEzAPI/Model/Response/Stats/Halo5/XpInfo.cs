namespace HaloEzAPI.Model.Response.Stats.Halo5
{
    public class XpInfo
    {
        public int PrevSpartanRank { get; set; }
        public int SpartanRank { get; set; }
        public int PrevTotalXP { get; set; }
        public int TotalXP { get; set; }
        public double SpartanRankMatchXPScalar { get; set; }
        public int PlayerTimePerformanceXPAward { get; set; }
        public int PerformanceXP { get; set; }
        public int PlayerRankXPAward { get; set; }
        public int BoostAmount { get; set; }
        public int MatchSpeedWinAmount { get; set; }
        public int ObjectiveCompletedAmount { get; set; }
        public BoostData BoostData { get; set; }
    }
}