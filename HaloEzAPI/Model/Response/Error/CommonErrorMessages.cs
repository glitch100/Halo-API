namespace HaloEzAPI.Model.Response.Error
{
    public static class CommonErrorMessages
    {
        public static string CantDeserialize { get { return "Unable to Deserialize Object"; } }
        public static string InvalidGamerTag { get { return "Invalid GamerTag provided"; } }
        public static string InvalidMatchId { get { return "Invalid MatchId provided"; } }
        public static string AccessDenied { get { return "Access Denied - Invalid or No API Token provided"; } }
        public static string TooManyRequests { get { return "Too many requests, please wait before sending more."; } }
        public static string BadRequest { get { return "Bad Request - please check the parameters you are passing, or the API Endpoint"; } }
    }
}