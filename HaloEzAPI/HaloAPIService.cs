using System;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using HaloEzAPI.Abstraction.Enum;
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

            public static Uri GetMatchesForPlayer(string gamertag, GameMode gamemode = GameMode.Any, int start = 0, int count = 25)
            {
                var values = new NameValueCollection();
                if (gamemode != GameMode.Any)
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
                    throw new NotImplementedException();
                    return new Uri(string.Format("{0}/{1}/{2}/campaign/matches/{3}", MajorPrefix, MinorPrefix, Title, matchId));
                }                
                if (gameMode == GameMode.Custom)
                {
                    throw new NotImplementedException();
                    return new Uri(string.Format("{0}/{1}/{2}/custom/matches/{3}", MajorPrefix, MinorPrefix, Title, matchId));
                }
                if (gameMode == GameMode.Warzone)
                {
                    throw new NotImplementedException();
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
        private readonly HttpClient _httpClient;

        public HaloAPIService(string apiToken, string baseApiUrl = "https://www.haloapi.com")
        {
            Endpoints.MajorPrefix = baseApiUrl;
            _httpClient = new HttpClient(new HttpClientHandler());
            _httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", apiToken);
        }

        private async Task<T> HandleResponse<T>(HttpResponseMessage message)
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
            throw  new HaloAPIException("Unknown Error in HandleResponse");
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
            var message = await _httpClient.GetAsync(Endpoints.Stats.GetMatchesForPlayer(gamerTag,gameMode,start,count));
            var messageObject = await HandleResponse<PlayerMatches>(message);
            return messageObject;
        }

        /// <summary>
        /// Get a post game carnage report for a specified match id
        /// </summary>
        /// <param name="matchId">The Match Id</param>
        /// <returns></returns>
        public async Task<ArenaPostGameReport> GetArenaPostGameCarnageReport(string matchId)
        {
            var message = await _httpClient.GetAsync(Endpoints.Stats.GetPostGameCarnageReport(matchId,GameMode.Arena));
            var messageObject = await HandleResponse<ArenaPostGameReport>(message);
            return messageObject;
        }         
        
        /// <summary>
        /// Gets Arena Service Record for specified list of players
        /// </summary>
        /// <param name="players">Up to 32 Players can be requested</param>
        /// <returns></returns>
        public async Task<ServiceRecordQueryResponse> GetArenaServiceRecords([Range(1, 32)]string[] players)
        {
            var message = await _httpClient.GetAsync(Endpoints.Stats.GetServiceRecords(players, GameMode.Arena));
            var messageObject = await HandleResponse<ServiceRecordQueryResponse>(message);
            return messageObject;
        } 
    }
}
