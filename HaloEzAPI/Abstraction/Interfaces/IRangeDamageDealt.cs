namespace HaloEzAPI.Abstraction.Interfaces
{
    public interface IRangeDamageDealt
    {
        int TotalHeadshots { get; set; }
        double TotalWeaponDamage { get; set; }
        int TotalShotsFired { get; set; }
        int TotalShotsLanded { get; set; }
    }
}