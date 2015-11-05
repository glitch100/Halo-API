using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using HaloEzAPI.Abstraction.Enum;
using HaloEzAPI.Abstraction.Interfaces;
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
                    values.Add("modes", Convert.ToInt32(gamemode).ToString());
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

            public static Uri GetArenaPostGameCarnageReport(string matchId)
            {
                return new Uri(string.Format("{0}/{1}/{2}/arena/matches{3}", MajorPrefix, MinorPrefix, Title, matchId));
            }
        }
    }

    public class HaloAPIService : IHaloAPIService
    {
        private readonly HttpClient _httpClient;

        public HaloAPIService(string apiToken, string baseApiUrl)
        {
            Endpoints.MajorPrefix = baseApiUrl;
            _httpClient = new HttpClient(new HttpClientHandler());
            _httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", apiToken);
        }

        /// <summary>
        /// Get matches for a specific player, for specific gamemodes, and paginated
        /// </summary>
        /// <param name="gamerTag">Players gamertag</param>
        /// <param name="gameMode">Any gamemodes to filter by</param>
        /// <param name="start">Start of result set</param>
        /// <param name="count">Count of results at any one time</param>
        /// <returns></returns>
        public async Task<PlayerMatches> GetMatchesForPlayer(string gamerTag, GameMode gameMode, int start, int count)
        {
            var message = await _httpClient.GetAsync(Endpoints.Stats.GetMatchesForPlayer(gamerTag,gameMode,start,count));
            var messageJson = await message.Content.ReadAsStringAsync();
            var messageObject = JsonConvert.DeserializeObject<PlayerMatches>(messageJson);
            if (messageObject == null)
            {
                throw new HaloAPIException() { StandardMessage = "Unable to deserialize object." };
            }
            return messageObject;
        }

        /// <summary>
        /// Get a post game carnage report for a specified match id
        /// </summary>
        /// <param name="matchId">The Match Id</param>
        /// <returns></returns>
        public async Task<IEnumerable<PlayerStat>> GetArenaPostGameCarnageReport(string matchId)
        {
            var message = await _httpClient.GetAsync(Endpoints.Stats.GetArenaPostGameCarnageReport(matchId));
            var messageJson = await message.Content.ReadAsStringAsync();
            var messageObject = JsonConvert.DeserializeObject<IEnumerable<PlayerStat>>(messageJson);
            if (messageObject == null)
            {
                throw new HaloAPIException() {StandardMessage = "Unable to deserialize object."};
            }
            return messageObject;
        } 
    }
}
