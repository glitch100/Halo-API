namespace HaloEzAPI.Model.Response.UGC
{
    public class UGCGameVariant : UGCBase
    {
        public int BaseEngineGameType { get; set; }
        public int ScoreToWin { get; set; }
        public int NumberOfLives { get; set; }
        public int MatchDurationInSeconds { get; set; }
    }
}
