using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using HaloEzAPI.Abstraction.Enum;
using HaloEzAPI.Caching;
using HaloEzAPI.Limits;
using HaloEzAPI.Model.Response.Error;
using HaloEzAPI.Model.Response.MetaData;
using HaloEzAPI.Model.Response.Stats;
using Newtonsoft.Json;

namespace HaloEzAPI
{
    public class HaloAPIService : IHaloAPIService
    {
        private const int StatCacheExpiry = 1;
        private const int MetaCacheExpiry = 24;

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
            if (message.StatusCode == HttpStatusCode.BadRequest)
            {
                throw new HaloAPIException(CommonErrorMessages.BadRequest);   
            }
            if (message.StatusCode == (HttpStatusCode) 429)
            {
                throw new HaloAPIException(CommonErrorMessages.TooManyRequests);
            }
            throw new HaloAPIException(string.Format("Unknown Error in HandleResponse: {0}",message.RequestMessage));
        }

        private async Task<T> ProcessRequest<T>(Uri endpoint,int cacheExpiryMin) where T : class
        {
            string key = endpoint.AbsoluteUri;
            if (CacheManager.Contains(key))
            {
                return CacheManager.Get<T>(key);
            }
            var message = await RequestRateHttpClient.GetRequest(endpoint);
            var messageObject = await HandleResponse<T>(message);
            CacheManager.Add<T>(messageObject, key, cacheExpiryMin);
            return messageObject;
        }

        #region Stats

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
            return await ProcessRequest<PlayerMatches>(Endpoints.Stats.GetMatchesForPlayer(gamerTag, gameMode, start, count), StatCacheExpiry);
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
            return await ProcessRequest<ArenaPostGameReport>(Endpoints.Stats.GetPostGameCarnageReport(matchId.ToString(), GameMode.Arena), StatCacheExpiry);
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
            return await ProcessRequest<CampaignPostGameReport>(Endpoints.Stats.GetPostGameCarnageReport(matchId.ToString(), GameMode.Campaign), StatCacheExpiry);
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
            return await ProcessRequest<CustomPostGameReport>(Endpoints.Stats.GetPostGameCarnageReport(matchId.ToString(), GameMode.Custom), StatCacheExpiry);
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
            return await ProcessRequest<WarzonePostGameReport>(Endpoints.Stats.GetPostGameCarnageReport(matchId.ToString(), GameMode.Warzone), StatCacheExpiry);
        }
        #endregion 

        #region Service Records
        /// <summary>
        /// Gets Arena Service Record for specified list of players
        /// </summary>
        /// <param name="players">Up to 32 Players can be requested</param>
        /// <returns></returns>
        public async Task<ArenaServiceRecordQueryResponse> GetArenaServiceRecords([MaxLength(32)]string[] players)
        {
            return await ProcessRequest<ArenaServiceRecordQueryResponse>(Endpoints.Stats.GetServiceRecords(players, GameMode.Arena), StatCacheExpiry);
        }        
        
        /// <summary>
        /// Get Campaign Service Record for specified list of players
        /// </summary>
        /// <param name="players">Up to 32 players can be requested></param>
        /// <returns></returns>
        public async Task<CampaignServiceRecordQueryResponse> GetCampaignServiceRecords([MaxLength(32)]string[] players)
        {
            return await ProcessRequest<CampaignServiceRecordQueryResponse>(Endpoints.Stats.GetServiceRecords(players, GameMode.Campaign), StatCacheExpiry);
        }

        /// <summary>
        /// Get Custom Game Service Record for specified list of players
        /// </summary>
        /// <param name="players">Up to 32 players can be requested></param>
        /// <returns></returns>
        public async Task<CustomGameServiceRecordQueryResponse> GetCustomGameServiceRecords([MaxLength(32)] string[] players)
        {
            return await ProcessRequest<CustomGameServiceRecordQueryResponse>(Endpoints.Stats.GetServiceRecords(players, GameMode.Custom), StatCacheExpiry);
        }

        /// <summary>
        /// Get Warzone Service Record for specified list of players
        /// </summary>
        /// <param name="players">Up to 32 players can be requested></param>
        /// <returns></returns>
        public async Task<WarzoneServiceRecordQueryResponse> GetWarzoneServiceRecords([MaxLength(32)] string[] players)
        {
            return await ProcessRequest<WarzoneServiceRecordQueryResponse>(Endpoints.Stats.GetServiceRecords(players, GameMode.Warzone), StatCacheExpiry);
        }
        #endregion

        #endregion 

        #region MetaData

        public async Task<IEnumerable<CampaignMission>> GetCampaignMissions()
        {
            return await ProcessRequest<IEnumerable<CampaignMission>>(Endpoints.MetaData.GetCampaignMissions(), MetaCacheExpiry);
        }

        public async Task<IEnumerable<Commendation>> GetCommendations()
        {
            return await ProcessRequest<IEnumerable<Commendation>>(Endpoints.MetaData.GetCommendations(), MetaCacheExpiry);
        }

        public async Task<IEnumerable<Enemy>> GetEnemies()
        {
            return await ProcessRequest<IEnumerable<Enemy>>(Endpoints.MetaData.GetEnemies(), MetaCacheExpiry);
        }

        public async Task<IEnumerable<FlexibleStat>> GetFlexibleStats()
        {
            return await ProcessRequest<IEnumerable<FlexibleStat>>(Endpoints.MetaData.GetFlexibleStats(), MetaCacheExpiry);
        }

        public async Task<IEnumerable<GameBaseVariant>> GetGameBaseVariants()
        {
            return await ProcessRequest<IEnumerable<GameBaseVariant>>(Endpoints.MetaData.GetGameBaseVariants(), MetaCacheExpiry);
        }

        public async Task<GameVariant> GetGameVariant(string id)
        {
            return await ProcessRequest<GameVariant>(Endpoints.MetaData.GetGameVariant(id), MetaCacheExpiry);
        }

        #endregion
    }
}
