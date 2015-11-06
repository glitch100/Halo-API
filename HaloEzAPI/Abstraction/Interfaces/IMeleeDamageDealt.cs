namespace HaloEzAPI.Abstraction.Interfaces
{
    public interface IMeleeDamageDealt
    {
        int TotalMeleeKills { get; set; }
        double TotalMeleeDamage { get; set; }
        int TotalAssassinations { get; set; }
        int TotalGroundPoundKills { get; set; }
        double TotalGroundPoundDamage { get; set; }
        int TotalShoulderBashKills { get; set; }
        double TotalShoulderBashDamage { get; set; }
    }
}