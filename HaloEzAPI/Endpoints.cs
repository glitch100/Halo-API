using System;
using System.Collections.Specialized;
using HaloEzAPI.Abstraction.Enum;
using HaloEzAPI.Model.Response.Error;

namespace HaloEzAPI
{
    internal static class Endpoints
    {
        internal static string MajorPrefix;
        private const string Title = "h5";

        public static class Stats
        {
            public static readonly string MinorPrefix = "stats";

            public static Uri GetMatchesForPlayer(string gamertag, GameMode gamemode = GameMode.All, int start = 0, int count = 25)
            {
                var values = new NameValueCollection();

                if (gamemode != GameMode.All)
                {
                    values.Add("modes", gamemode.ToString().ToLower());
                }

                if (start > 0)
                {
                    values.Add("start", start.ToString());
                }
                if (count > 0 && count < 25 )
                {
                    values.Add("count",count.ToString());
                }
                string baseUrl = string.Format("{0}/{1}/{2}/players/{3}/matches?",MajorPrefix,MinorPrefix,Title,gamertag);
                return values.BuildUri(baseUrl);
            }

            public static Uri GetPostGameCarnageReport(string matchId, GameMode gameMode)
            {
                if (gameMode == GameMode.Arena)
                {
                    return new Uri(string.Format("{0}/{1}/{2}/arena/matches/{3}", MajorPrefix, MinorPrefix, Title, matchId));
                }
                if (gameMode == GameMode.Campaign)
                {
                    return new Uri(string.Format("{0}/{1}/{2}/campaign/matches/{3}", MajorPrefix, MinorPrefix, Title, matchId));
                }                
                if (gameMode == GameMode.Custom)
                {
                    return new Uri(string.Format("{0}/{1}/{2}/custom/matches/{3}", MajorPrefix, MinorPrefix, Title, matchId));
                }
                if (gameMode == GameMode.Warzone)
                {
                    return new Uri(string.Format("{0}/{1}/{2}/warzone/matches/{3}", MajorPrefix, MinorPrefix, Title, matchId));
                }
                throw new HaloAPIException("Unsupported GameMode provided for Post Game Carnage Report");
            }            
            
            public static Uri GetServiceRecords(string[] players, GameMode gameMode)
            {
                if (gameMode == GameMode.Arena)
                {
                    return new Uri(string.Format("{0}/{1}/{2}/servicerecords/arena?players={3}", MajorPrefix, MinorPrefix, Title, string.Join(",",players)));
                }
                if (gameMode == GameMode.Campaign)
                {
                    return new Uri(string.Format("{0}/{1}/{2}/servicerecords/campaign?players={3}", MajorPrefix, MinorPrefix, Title, string.Join(",", players)));
                }                
                if (gameMode == GameMode.Custom)
                {
                    return new Uri(string.Format("{0}/{1}/{2}/servicerecords/custom?players={3}", MajorPrefix, MinorPrefix, Title, string.Join(",", players)));
                }
                throw new HaloAPIException("Unsupported GameMode provided for Service Record. Please use Arena, or Campaign");
            }
        }
    }
}