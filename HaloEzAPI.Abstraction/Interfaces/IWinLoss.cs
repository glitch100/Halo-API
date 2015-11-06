using System;

namespace HaloEzAPI.Abstraction.Interfaces
{
    public interface IWinLoss
    {
        int TotalGamesCompleted { get; set; }
        int TotalGamesWon { get; set; }
        int TotalGamesLost { get; set; }
        int TotalGamesTied { get; set; }
        TimeSpan TotalTimePlayed { get; set; }
    }
}