namespace HaloEzAPI.Model.Response
{
    public class WeaponKillDetail
    {
        public WeaponId WeaponId { get; set; }
        public int TotalKills { get; set; }
        public int TotalHeadshots { get; set; }
        public double TotalDamageDealt { get; set; }
        public int TotalShotsFired { get; set; }
        public int TotalShotsLanded { get; set; }
        public string TotalPossessionTime { get; set; }
    }
}