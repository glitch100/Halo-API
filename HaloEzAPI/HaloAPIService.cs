﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Threading.Tasks;
using HaloEzAPI.Abstraction.Enum;
using HaloEzAPI.Abstraction.Interfaces;
using HaloEzAPI.Caching;
using HaloEzAPI.Limits;
using HaloEzAPI.Model.Request;
using HaloEzAPI.Model.Response.Error;
using HaloEzAPI.Model.Response.MetaData;
using HaloEzAPI.Model.Response.Stats;
using HaloEzAPI.Model.Response.UGC;

namespace HaloEzAPI
{
    public class HaloAPIService : IHaloAPIService
    {
        private readonly ResponseProcessor _responseProcessor;
        private const int StatCacheExpiry = 1;
        private const int MetaCacheExpiry = 24;
        private const int ProfileCacheExpiry = 24;
        private const int UGCCacheExpiry = 2;
        private const string BaseApiUrl = "https://www.haloapi.com";

        public HaloAPIService(string apiToken, string baseApiUrl = BaseApiUrl, IApiCacheManager apiCache = null)
        {
            Endpoints.MajorPrefix = baseApiUrl;
            RequestRateHttpClient.SetAPIToken(apiToken);
            if (apiCache == null)
            {
                apiCache = SingletonCacheManager.Instance;
            }
            _responseProcessor = new ResponseProcessor(apiCache);
        }

        #region Stats

        /// <summary>
        /// Get matches for a specific player, for specific gamemodes, and paginated
        /// </summary>
        /// <param name="gamerTag">Players gamertag</param>
        /// <param name="gameMode">Any gamemodes to filter by</param>
        /// <param name="start">Start of result set</param>
        /// <param name="count">Count of results at any one time</param>
        /// <param name="bustCache">Whether to bust the cache and repopulate it with the new result</param>
        /// <returns></returns>
        public async Task<PlayerMatches> GetMatchesForPlayer(string gamerTag, GameMode gameMode, int start = 0, int count = 25, bool bustCache = false)
        {
            if (string.IsNullOrEmpty(gamerTag))
            {
                throw new HaloAPIException(CommonErrorMessages.InvalidGamerTag);
            }
            return await _responseProcessor.ProcessRequest<PlayerMatches>(Endpoints.Stats.GetMatchesForPlayer(gamerTag, gameMode, start, count), StatCacheExpiry, bustCache);
        }

        /// <summary>
        /// Gets the Player leaderboard for a season and playlist
        /// </summary>
        /// <param name="seasonId">Season Id</param>
        /// <param name="playlistId">Playlist Id</param>
        /// <param name="count">Count of results at any one time, defaults to 200, cannot be 0</param>
        /// <param name="bustCache"></param>
        /// <returns></returns>
        public async Task<PlayerLeaderboardResults> PlayerLeaderboard(string seasonId, string playlistId, int count = 200, bool bustCache = false)
        {
            return await _responseProcessor.ProcessRequest<PlayerLeaderboardResults>(Endpoints.Stats.PlayerLeaderboard(seasonId, playlistId, count), StatCacheExpiry, bustCache);
        }

        public async Task<MatchEvent> GetEventsForMatch(string matchId, bool bustCache = false)
        {
            if (string.IsNullOrEmpty(matchId))
            {
                throw new HaloAPIException(CommonErrorMessages.InvalidMatchId);
            }
            return await _responseProcessor.ProcessRequest<MatchEvent>(Endpoints.Stats.GetEventsForMatch(matchId), StatCacheExpiry, bustCache);
        }

        #region Post Game Carnage Report

        /// <summary>
        /// Get a post game carnage report for a specified match id
        /// </summary>
        /// <param name="matchId">The Match Id</param>
        /// <returns></returns>
        public async Task<ArenaPostGameReport> GetArenaPostGameCarnageReport(Guid matchId, bool bustCache = false)
        {
            if (matchId == Guid.Empty)
            {
                throw new HaloAPIException(CommonErrorMessages.InvalidMatchId);
            }
            return await _responseProcessor.ProcessRequest<ArenaPostGameReport>(Endpoints.Stats.GetPostGameCarnageReport(matchId.ToString(), GameMode.Arena), StatCacheExpiry, bustCache);
        }

        /// <summary>
        /// Get Campaign Post Game Carnage report for a specified match id
        /// </summary>
        /// <param name="matchId">The match id</param>
        /// <returns></returns>
        public async Task<CampaignPostGameReport> GetCampaignPostGameCarnageReport(Guid matchId, bool bustCache = false)
        {
            if (matchId == Guid.Empty)
            {
                throw new HaloAPIException(CommonErrorMessages.InvalidMatchId);
            }
            return await _responseProcessor.ProcessRequest<CampaignPostGameReport>(Endpoints.Stats.GetPostGameCarnageReport(matchId.ToString(), GameMode.Campaign), StatCacheExpiry, bustCache);
        }

        /// <summary>
        /// Get Custom Post Game Carnage report for a specified match id
        /// </summary>
        /// <param name="matchId">The match id</param>
        /// <returns></returns>
        public async Task<CustomPostGameReport> GetCustomPostGameCarnageReport(Guid matchId, bool bustCache = false)
        {
            if (matchId == Guid.Empty)
            {
                throw new HaloAPIException(CommonErrorMessages.InvalidMatchId);
            }
            return await _responseProcessor.ProcessRequest<CustomPostGameReport>(Endpoints.Stats.GetPostGameCarnageReport(matchId.ToString(), GameMode.Custom), StatCacheExpiry, bustCache);
        }       
        
        /// <summary>
        /// Get Warzone Post Game Carnage report for a specified match id
        /// </summary>
        /// <param name="matchId">The match id</param>
        /// <returns></returns>
        public async Task<WarzonePostGameReport> GetWarzonePostGameCarnageReport(Guid matchId, bool bustCache = false)
        {
            if (matchId == Guid.Empty)
            {
                throw new HaloAPIException(CommonErrorMessages.InvalidMatchId);
            }
            return await _responseProcessor.ProcessRequest<WarzonePostGameReport>(Endpoints.Stats.GetPostGameCarnageReport(matchId.ToString(), GameMode.Warzone), StatCacheExpiry, bustCache);
        }
        #endregion 

        #region Service Records
        /// <summary>
        /// Gets Arena Service Record for specified list of players
        /// </summary>
        /// <param name="players">Up to 32 Players can be requested</param>
        /// <returns></returns>
        public async Task<ArenaServiceRecordQueryResponse> GetArenaServiceRecords([MaxLength(32)]string[] players, string seasonId = "", bool bustCache = false)
        {
            return await _responseProcessor.ProcessRequest<ArenaServiceRecordQueryResponse>(Endpoints.Stats.GetServiceRecords(players, GameMode.Arena, seasonId), StatCacheExpiry, bustCache);
        }        
        
        /// <summary>
        /// Get Campaign Service Record for specified list of players
        /// </summary>
        /// <param name="players">Up to 32 players can be requested></param>
        /// <returns></returns>
        public async Task<CampaignServiceRecordQueryResponse> GetCampaignServiceRecords([MaxLength(32)]string[] players, bool bustCache = false)
        {
            return await _responseProcessor.ProcessRequest<CampaignServiceRecordQueryResponse>(Endpoints.Stats.GetServiceRecords(players, GameMode.Campaign), StatCacheExpiry, bustCache);
        }

        /// <summary>
        /// Get Custom Game Service Record for specified list of players
        /// </summary>
        /// <param name="players">Up to 32 players can be requested></param>
        /// <returns></returns>
        public async Task<CustomGameServiceRecordQueryResponse> GetCustomGameServiceRecords([MaxLength(32)] string[] players, bool bustCache = false)
        {
            return await _responseProcessor.ProcessRequest<CustomGameServiceRecordQueryResponse>(Endpoints.Stats.GetServiceRecords(players, GameMode.Custom), StatCacheExpiry, bustCache);
        }

        /// <summary>
        /// Get Warzone Service Record for specified list of players
        /// </summary>
        /// <param name="players">Up to 32 players can be requested></param>
        /// <returns></returns>
        public async Task<WarzoneServiceRecordQueryResponse> GetWarzoneServiceRecords([MaxLength(32)] string[] players, bool bustCache = false)
        {
            return await _responseProcessor.ProcessRequest<WarzoneServiceRecordQueryResponse>(Endpoints.Stats.GetServiceRecords(players, GameMode.Warzone), StatCacheExpiry, bustCache);
        }
        #endregion

        #endregion 

        #region MetaData

        public async Task<IEnumerable<CampaignMission>> GetCampaignMissions(bool bustCache = false)
        {
            return await _responseProcessor.ProcessRequest<IEnumerable<CampaignMission>>(Endpoints.MetaData.GetCampaignMissions(), MetaCacheExpiry, bustCache);
        }

        public async Task<IEnumerable<Commendation>> GetCommendations(bool bustCache = false)
        {
            return await _responseProcessor.ProcessRequest<IEnumerable<Commendation>>(Endpoints.MetaData.GetCommendations(), MetaCacheExpiry, bustCache);
        }

        public async Task<IEnumerable<CSRDesignation>> GetCSRDesignations(bool bustCache = false)
        {
            return await _responseProcessor.ProcessRequest<IEnumerable<CSRDesignation>>(Endpoints.MetaData.GetCSRDesignations(), MetaCacheExpiry, bustCache);
        }

        public async Task<IEnumerable<Enemy>> GetEnemies(bool bustCache = false)
        {
            return await _responseProcessor.ProcessRequest<IEnumerable<Enemy>>(Endpoints.MetaData.GetEnemies(), MetaCacheExpiry, bustCache);
        }

        public async Task<IEnumerable<FlexibleStat>> GetFlexibleStats(bool bustCache = false)
        {
            return await _responseProcessor.ProcessRequest<IEnumerable<FlexibleStat>>(Endpoints.MetaData.GetFlexibleStats(), MetaCacheExpiry, bustCache);
        }

        public async Task<IEnumerable<GameBaseVariant>> GetGameBaseVariants(bool bustCache = false)
        {
            return await _responseProcessor.ProcessRequest<IEnumerable<GameBaseVariant>>(Endpoints.MetaData.GetGameBaseVariants(), MetaCacheExpiry, bustCache);
        }

        public async Task<GameVariant> GetGameVariant(string id, bool bustCache = false)
        {
            return await _responseProcessor.ProcessRequest<GameVariant>(Endpoints.MetaData.GetGameVariant(id), MetaCacheExpiry, bustCache);
        }

        public async Task<IEnumerable<Impulse>> GetImpulses(bool bustCache = false)
        {
            return await _responseProcessor.ProcessRequest<IEnumerable<Impulse>>(Endpoints.MetaData.GetImpulses(), MetaCacheExpiry, bustCache);
        }

        public async Task<MapVariant> GetMapVariant(string id, bool bustCache = false)
        {
            return await _responseProcessor.ProcessRequest<MapVariant>(Endpoints.MetaData.GetMapVariants(id), MetaCacheExpiry, bustCache);
        }

        public async Task<IEnumerable<Map>> GetMaps(bool bustCache = false)
        {
            return await _responseProcessor.ProcessRequest<IEnumerable<Map>>(Endpoints.MetaData.GetMaps(), MetaCacheExpiry, bustCache);
        }

        public async Task<IEnumerable<Medal>> GetMedals(bool bustCache = false)
        {
            return await _responseProcessor.ProcessRequest<IEnumerable<Medal>>(Endpoints.MetaData.GetMedals(), MetaCacheExpiry, bustCache);
        }

        public async Task<IEnumerable<Playlist>> GetPlaylists(bool bustCache = false)
        {
            return await _responseProcessor.ProcessRequest<IEnumerable<Playlist>>(Endpoints.MetaData.GetPlaylists(), MetaCacheExpiry, bustCache);
        }

        public async Task<IEnumerable<RequisitionPack>> GetRequisitionPacks(bool bustCache = false)
        {
            return await _responseProcessor.ProcessRequest<IEnumerable<RequisitionPack>>(Endpoints.MetaData.GetRequisitionPacks(), MetaCacheExpiry, bustCache);
        }

        public async Task<RequisitionPack> GetRequisitionPack(Guid id, bool bustCache = false)
        {
            return await _responseProcessor.ProcessRequest<RequisitionPack>(Endpoints.MetaData.GetRequisitionPack(id), MetaCacheExpiry, bustCache);
        }

        public async Task<RequisitionPack> GetRequisition(Guid id, bool bustCache = false)
        {
            return await _responseProcessor.ProcessRequest<RequisitionPack>(Endpoints.MetaData.GetRequisition(id), MetaCacheExpiry, bustCache);
        }

        public async Task<IEnumerable<Skull>> GetSkulls(bool bustCache = false)
        {
            return await _responseProcessor.ProcessRequest<IEnumerable<Skull>>(Endpoints.MetaData.GetSkulls(), MetaCacheExpiry, bustCache);
        }

        public async Task<IEnumerable<SpartanRank>> GetSpartanRanks(bool bustCache = false)
        {
            return await _responseProcessor.ProcessRequest<IEnumerable<SpartanRank>>(Endpoints.MetaData.GetSpartanRanks(), MetaCacheExpiry, bustCache);
        }

        public async Task<IEnumerable<TeamColor>> GetTeamColours(bool bustCache = false)
        {
            return await _responseProcessor.ProcessRequest<IEnumerable<TeamColor>>(Endpoints.MetaData.GetTeamColors(), MetaCacheExpiry, bustCache);
        }

        public async Task<IEnumerable<Vehicle>> GetVehicles(bool bustCache = false)
        {
            return await _responseProcessor.ProcessRequest<IEnumerable<Vehicle>>(Endpoints.MetaData.GetVehicles(), MetaCacheExpiry, bustCache);
        }

        public async Task<IEnumerable<Weapon>> GetWeapons(bool bustCache = false)
        {
            return await _responseProcessor.ProcessRequest<IEnumerable<Weapon>>(Endpoints.MetaData.GetWeapons(), MetaCacheExpiry, bustCache);
        }

        public async Task<IEnumerable<Season>> GetSeasons(bool bustCache = false)
        {
            return await _responseProcessor.ProcessRequest<IEnumerable<Season>>(Endpoints.MetaData.GetSeasons(), MetaCacheExpiry, bustCache);
        }

        #endregion

        #region Profile
        public async Task<Image> GetProfileEmblem(string gamerTag, int size = 256, bool bustCache = false)
        {
            return await _responseProcessor.ProcessImageRequest(Endpoints.Profile.GetEmblemImage(gamerTag, size), ProfileCacheExpiry, bustCache);
        }

        public async Task<Image> GetSpartanImage(string gamerTag, int size = 256, CropType cropType = CropType.Full, bool bustCache = false)
        {
            return await _responseProcessor.ProcessImageRequest(Endpoints.Profile.GetSpartanImage(gamerTag, size, cropType), ProfileCacheExpiry, bustCache);
        }
        #endregion

        #region UGC

        /// <summary>
        /// Get a specific UGC Game Variant for a specific player via id
        /// </summary>
        /// <param name="gamerTag">Players gamertag</param>
        /// <param name="variantId">Id of the game variant</param>
        /// <returns></returns>
        public async Task<UGCGameVariant> GetUGCGameVariant(string gamerTag, string variantId, bool bustCache = false)
        {
            if (string.IsNullOrEmpty(gamerTag))
            {
                throw new HaloAPIException(CommonErrorMessages.InvalidGamerTag);
            }
            return await _responseProcessor.ProcessRequest<UGCGameVariant>(Endpoints.UGC.GetGameVariant(gamerTag, variantId), UGCCacheExpiry, bustCache);
        }

        /// <summary>
        /// Get a specific UGC Map Variant for a specific player via id
        /// </summary>
        /// <param name="gamerTag">Players gamertag</param>
        /// <param name="variantId">Id of the game variant</param>
        /// <returns></returns>
        public async Task<UGCBase> GetUGCMapVariant(string gamerTag, string variantId, bool bustCache = false)
        {
            if (string.IsNullOrEmpty(gamerTag))
            {
                throw new HaloAPIException(CommonErrorMessages.InvalidGamerTag);
            }
            return await _responseProcessor.ProcessRequest<UGCBase>(Endpoints.UGC.GetMapVariant(gamerTag, variantId), UGCCacheExpiry, bustCache);
        }

        /// <summary>
        /// Returns a list of UGC Map Variants for a specific player
        /// </summary>
        /// <param name="gamerTag">Players gamertag</param>
        /// <param name="start"></param>
        /// <param name="count"></param>
        /// <param name="sort"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public async Task<UGCSearchResult<UGCBase>> GetUGCMapVariants(string gamerTag, int start, int count, Sort sort, Order order, bool bustCache = false)
        {
            if (string.IsNullOrEmpty(gamerTag))
            {
                throw new HaloAPIException(CommonErrorMessages.InvalidGamerTag);
            }
            return await _responseProcessor.ProcessRequest<UGCSearchResult<UGCBase>>(Endpoints.UGC.ListMapVariants(gamerTag, start, count, sort, order), UGCCacheExpiry, bustCache);
        }

        /// <summary>
        /// Returns a list of UGC Game Variants for a specific player
        /// </summary>
        /// <param name="gamerTag">Players gamertag</param>
        /// <param name="start"></param>
        /// <param name="count"></param>
        /// <param name="sort"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public async Task<UGCSearchResult<UGCBase>> GetUGCGameVariants(string gamerTag, int start, int count, Sort sort, Order order, bool bustCache = false)
        {
            if (string.IsNullOrEmpty(gamerTag))
            {
                throw new HaloAPIException(CommonErrorMessages.InvalidGamerTag);
            }
            return await _responseProcessor.ProcessRequest<UGCSearchResult<UGCBase>>(Endpoints.UGC.ListGameVariants(gamerTag, start, count, sort, order), UGCCacheExpiry, bustCache);
        }
        #endregion
    }
}
