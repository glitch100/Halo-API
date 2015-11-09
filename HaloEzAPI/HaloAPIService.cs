using System;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using HaloEzAPI.Abstraction.Enum;
using HaloEzAPI.Limits;
using HaloEzAPI.Model.Response;
using HaloEzAPI.Model.Response.Error;
using Newtonsoft.Json;

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
                throw new HaloAPIException("Unsupported GameMode provided for Service Record. Please use Arena, or Campaign");
            }
        }
    }

    public class HaloAPIService : IHaloAPIService
    {
        public HaloAPIService(string apiToken, string baseApiUrl = "https://www.haloapi.com")
        {
            Endpoints.MajorPrefix = baseApiUrl;
            RequestRateHttpClient.SetAPIToken(apiToken);
        }

        private async Task<T> HandleResponse<T>(HttpResponseMessage message)  where T : class 
        {
            if (message.IsSuccessStatusCode)
            {
                var messageJson = await message.Content.ReadAsStringAsync();
                var messageObject = JsonConvert.DeserializeObject<T>(messageJson);
                if (messageObject == null)
                {
                    throw new HaloAPIException(CommonErrorMessages.CantDeserialize);
                }
                return messageObject;
            }
            if (message.StatusCode == HttpStatusCode.NotFound)
            {
                throw new HaloAPIException(message.ReasonPhrase);
            }
            if (message.StatusCode == HttpStatusCode.InternalServerError)
            {
                throw new HaloAPIException(message.ReasonPhrase);
            }
            if (message.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new HaloAPIException(CommonErrorMessages.AccessDenied);
            }
            if (message.StatusCode == (HttpStatusCode) 429)
            {
                throw new HaloAPIException(CommonErrorMessages.TooManyRequests);
            }
            throw new HaloAPIException(string.Format("Unknown Error in HandleResponse: {0}",message.RequestMessage));
        }

        /// <summary>
        /// Get matches for a specific player, for specific gamemodes, and paginated
        /// </summary>
        /// <param name="gamerTag">Players gamertag</param>
        /// <param name="gameMode">Any gamemodes to filter by</param>
        /// <param name="start">Start of result set</param>
        /// <param name="count">Count of results at any one time</param>
        /// <returns></returns>
        public async Task<PlayerMatches> GetMatchesForPlayer(string gamerTag, GameMode gameMode, int start = 0, int count = 25)
        {
            if (string.IsNullOrEmpty(gamerTag))
            {
                throw new HaloAPIException(CommonErrorMessages.InvalidGamerTag);
            }
            var message = await RequestRateHttpClient.GetRequest(Endpoints.Stats.GetMatchesForPlayer(gamerTag,gameMode,start,count));
            var messageObject = await HandleResponse<PlayerMatches>(message);
            return messageObject;
        }
        
        #region Post Game Carnage Report

        /// <summary>
        /// Get a post game carnage report for a specified match id
        /// </summary>
        /// <param name="matchId">The Match Id</param>
        /// <returns></returns>
        public async Task<ArenaPostGameReport> GetArenaPostGameCarnageReport(Guid matchId)
        {
            if (matchId == Guid.Empty)
            {
                throw new HaloAPIException(CommonErrorMessages.InvalidMatchId);
            }
            var message = await RequestRateHttpClient.GetRequest(Endpoints.Stats.GetPostGameCarnageReport(matchId.ToString(),GameMode.Arena));
            var messageObject = await HandleResponse<ArenaPostGameReport>(message);
            return messageObject;
        }

        /// <summary>
        /// Get Campaign Post Game Carnage report for a specified match id
        /// </summary>
        /// <param name="matchId">The match id</param>
        /// <returns></returns>
        public async Task<CampaignPostGameReport> GetCampaignPostGameCarnageReport(Guid matchId)
        {
            if (matchId == Guid.Empty)
            {
                throw new HaloAPIException(CommonErrorMessages.InvalidMatchId);
            }
            var message = await RequestRateHttpClient.GetRequest(Endpoints.Stats.GetPostGameCarnageReport(matchId.ToString(), GameMode.Campaign));
            var messageObject = await HandleResponse<CampaignPostGameReport>(message);
            return messageObject;
        }

        /// <summary>
        /// Get Custom Post Game Carnage report for a specified match id
        /// </summary>
        /// <param name="matchId">The match id</param>
        /// <returns></returns>
        public async Task<CustomPostGameReport> GetCustomPostGameCarnageReport(Guid matchId)
        {
            if (matchId == Guid.Empty)
            {
                throw new HaloAPIException(CommonErrorMessages.InvalidMatchId);
            }
            var message = await RequestRateHttpClient.GetRequest(Endpoints.Stats.GetPostGameCarnageReport(matchId.ToString(), GameMode.Custom));
            var messageObject = await HandleResponse<CustomPostGameReport>(message);
            return messageObject;
        }       
        
        /// <summary>
        /// Get Warzone Post Game Carnage report for a specified match id
        /// </summary>
        /// <param name="matchId">The match id</param>
        /// <returns></returns>
        public async Task<WarzonePostGameReport> GetWarzonePostGameCarnageReport(Guid matchId)
        {
            if (matchId == Guid.Empty)
            {
                throw new HaloAPIException(CommonErrorMessages.InvalidMatchId);
            }
            var message = await RequestRateHttpClient.GetRequest(Endpoints.Stats.GetPostGameCarnageReport(matchId.ToString(), GameMode.Warzone));
            var messageObject = await HandleResponse<WarzonePostGameReport>(message);
            return messageObject;
        }
        #endregion 

        /// <summary>
        /// Gets Arena Service Record for specified list of players
        /// </summary>
        /// <param name="players">Up to 32 Players can be requested</param>
        /// <returns></returns>
        public async Task<ArenaServiceRecordQueryResponse> GetArenaServiceRecords([MaxLength(32)]string[] players)
        {
            var message = await RequestRateHttpClient.GetRequest(Endpoints.Stats.GetServiceRecords(players, GameMode.Arena));
            var messageObject = await HandleResponse<ArenaServiceRecordQueryResponse>(message);
            return messageObject;
        }        
        
        /// <summary>
        /// Get Campaign Service Record for specified list of players
        /// </summary>
        /// <param name="players">Up to 32 players can be requested></param>
        /// <returns></returns>
        public async Task<CampaignServiceRecordQueryResponse> GetCampaignServiceRecords([MaxLength(32)]string[] players)
        {
            var message = await RequestRateHttpClient.GetRequest(Endpoints.Stats.GetServiceRecords(players, GameMode.Campaign));
            var messageObject = await HandleResponse<CampaignServiceRecordQueryResponse>(message);
            return messageObject;
        } 
    }
}
