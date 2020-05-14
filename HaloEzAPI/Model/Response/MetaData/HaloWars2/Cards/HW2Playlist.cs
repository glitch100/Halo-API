using HaloEzAPI.Model.Response.MetaData.HaloWars2.Views;

namespace HaloEzAPI.Model.Response.MetaData.HaloWars2.Cards
{
    public class HW2Playlist
    {
        public ComputerDifficulty ComputerDifficulty { get; set; }
        public ImageView ThumbnailImage { get; set; }
        public int MaxPartySize { get; set; }
        public int MinPartySize { get; set; }
        public bool UsesBanRules { get; set; }
        public int MatchTicketTimeoutDurationSeconds { get; set; }
        public string MpsdHopperName { get; set; }
    }
}