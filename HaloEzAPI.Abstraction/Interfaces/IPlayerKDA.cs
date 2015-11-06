namespace HaloEzAPI.Abstraction.Interfaces
{
    public interface IPlayerKDA
    {
        int TotalKills { get; set; }
        int TotalDeaths { get; set; }
        int TotalAssists { get; set; }
    }
}