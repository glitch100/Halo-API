namespace HaloEzAPI.Model.Response.Error
{
    public static class CommonErrorMessages
    {
        public static string CantDeserialize { get { return "Unable to Deserialize Object"; } }
        public static string InvalidGamerTag { get { return "Invalid GamerTag provided"; } }
        public static string InvalidMatchId { get { return "Invalid MatchId provided"; } }
    }
}