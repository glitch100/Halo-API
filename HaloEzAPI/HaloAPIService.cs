using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using HaloEzAPI.Abstraction.Enum;
using HaloEzAPI.Caching;
using HaloEzAPI.Limits;
using HaloEzAPI.Model.Request;
using HaloEzAPI.Model.Response.Error;
using HaloEzAPI.Model.Response.MetaData;
using HaloEzAPI.Model.Response.Stats;
using HaloEzAPI.Model.Response.UGC;
using Newtonsoft.Json;

namespace HaloEzAPI
{
    public class HaloAPIService : IHaloAPIService
    {
        private readonly ResponseProcessor _responseProcessor;
        private const int StatCacheExpiry = 1;
        private const int MetaCacheExpiry = 24;
        private const int ProfileCacheExpiry = 24;
        private const int UGCCacheExpiry = 2;

        public HaloAPIService(string apiToken, string baseApiUrl = "https://www.haloapi.com")
        {
            Endpoints.MajorPrefix = baseApiUrl;
            RequestRateHttpClient.SetAPIToken(apiToken);
            _responseProcessor = new ResponseProcessor();
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
            return await _responseProcessor.ProcessRequest<PlayerMatches>(Endpoints.Stats.GetMatchesForPlayer(gamerTag, gameMode, start, count), StatCacheExpiry);
        }

        /// <summary>
        /// Gets the Player leaderboard for a season and playlist
        /// </summary>
        /// <param name="seasonId">Season Id</param>
        /// <param name="playlistId">Playlist Id</param>
        /// <param name="count">Count of results at any one time, defaults to 200, cannot be 0</param>
        /// <returns></returns>
        public async Task<PlayerLeaderboardResults> PlayerLeaderboard(string seasonId, string playlistId, int count = 200)
        {
            return await _responseProcessor.ProcessRequest<PlayerLeaderboardResults>(Endpoints.Stats.PlayerLeaderboard(seasonId, playlistId, count), StatCacheExpiry);
        }

        public async Task<MatchEvent> GetEventsForMatch(string matchId)
        {
            if (string.IsNullOrEmpty(matchId))
            {
                throw new HaloAPIException(CommonErrorMessages.InvalidMatchId);
            }
            return await _responseProcessor.ProcessRequest<MatchEvent>(Endpoints.Stats.GetEventsForMatch(matchId), StatCacheExpiry);
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
            return await _responseProcessor.ProcessRequest<ArenaPostGameReport>(Endpoints.Stats.GetPostGameCarnageReport(matchId.ToString(), GameMode.Arena), StatCacheExpiry);
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
            return await _responseProcessor.ProcessRequest<CampaignPostGameReport>(Endpoints.Stats.GetPostGameCarnageReport(matchId.ToString(), GameMode.Campaign), StatCacheExpiry);
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
            return await _responseProcessor.ProcessRequest<CustomPostGameReport>(Endpoints.Stats.GetPostGameCarnageReport(matchId.ToString(), GameMode.Custom), StatCacheExpiry);
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
            return await _responseProcessor.ProcessRequest<WarzonePostGameReport>(Endpoints.Stats.GetPostGameCarnageReport(matchId.ToString(), GameMode.Warzone), StatCacheExpiry);
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
            return await _responseProcessor.ProcessRequest<ArenaServiceRecordQueryResponse>(Endpoints.Stats.GetServiceRecords(players, GameMode.Arena), StatCacheExpiry);
        }        
        
        /// <summary>
        /// Get Campaign Service Record for specified list of players
        /// </summary>
        /// <param name="players">Up to 32 players can be requested></param>
        /// <returns></returns>
        public async Task<CampaignServiceRecordQueryResponse> GetCampaignServiceRecords([MaxLength(32)]string[] players)
        {
            return await _responseProcessor.ProcessRequest<CampaignServiceRecordQueryResponse>(Endpoints.Stats.GetServiceRecords(players, GameMode.Campaign), StatCacheExpiry);
        }

        /// <summary>
        /// Get Custom Game Service Record for specified list of players
        /// </summary>
        /// <param name="players">Up to 32 players can be requested></param>
        /// <returns></returns>
        public async Task<CustomGameServiceRecordQueryResponse> GetCustomGameServiceRecords([MaxLength(32)] string[] players)
        {
            return await _responseProcessor.ProcessRequest<CustomGameServiceRecordQueryResponse>(Endpoints.Stats.GetServiceRecords(players, GameMode.Custom), StatCacheExpiry);
        }

        /// <summary>
        /// Get Warzone Service Record for specified list of players
        /// </summary>
        /// <param name="players">Up to 32 players can be requested></param>
        /// <returns></returns>
        public async Task<WarzoneServiceRecordQueryResponse> GetWarzoneServiceRecords([MaxLength(32)] string[] players)
        {
            return await _responseProcessor.ProcessRequest<WarzoneServiceRecordQueryResponse>(Endpoints.Stats.GetServiceRecords(players, GameMode.Warzone), StatCacheExpiry);
        }
        #endregion

        #endregion 

        #region MetaData

        public async Task<IEnumerable<CampaignMission>> GetCampaignMissions()
        {
            return await _responseProcessor.ProcessRequest<IEnumerable<CampaignMission>>(Endpoints.MetaData.GetCampaignMissions(), MetaCacheExpiry);
        }

        public async Task<IEnumerable<Commendation>> GetCommendations()
        {
            return await _responseProcessor.ProcessRequest<IEnumerable<Commendation>>(Endpoints.MetaData.GetCommendations(), MetaCacheExpiry);
        }

        public async Task<IEnumerable<Enemy>> GetEnemies()
        {
            return await _responseProcessor.ProcessRequest<IEnumerable<Enemy>>(Endpoints.MetaData.GetEnemies(), MetaCacheExpiry);
        }

        public async Task<IEnumerable<FlexibleStat>> GetFlexibleStats()
        {
            return await _responseProcessor.ProcessRequest<IEnumerable<FlexibleStat>>(Endpoints.MetaData.GetFlexibleStats(), MetaCacheExpiry);
        }

        public async Task<IEnumerable<GameBaseVariant>> GetGameBaseVariants()
        {
            return await _responseProcessor.ProcessRequest<IEnumerable<GameBaseVariant>>(Endpoints.MetaData.GetGameBaseVariants(), MetaCacheExpiry);
        }

        public async Task<GameVariant> GetGameVariant(string id)
        {
            return await _responseProcessor.ProcessRequest<GameVariant>(Endpoints.MetaData.GetGameVariant(id), MetaCacheExpiry);
        }

        public async Task<IEnumerable<Impulse>> GetImpulses()
        {
            return await _responseProcessor.ProcessRequest<IEnumerable<Impulse>>(Endpoints.MetaData.GetImpulses(), MetaCacheExpiry);
        }

        public async Task<MapVariant> GetMapVariant(string id)
        {
            return await _responseProcessor.ProcessRequest<MapVariant>(Endpoints.MetaData.GetMapVariants(id), MetaCacheExpiry);
        }

        public async Task<IEnumerable<Map>> GetMaps()
        {
            return await _responseProcessor.ProcessRequest<IEnumerable<Map>>(Endpoints.MetaData.GetMaps(), MetaCacheExpiry);
        }

        public async Task<IEnumerable<Medal>> GetMedals()
        {
            return await _responseProcessor.ProcessRequest<IEnumerable<Medal>>(Endpoints.MetaData.GetMedals(), MetaCacheExpiry);
        }

        public async Task<IEnumerable<Playlist>> GetPlaylists()
        {
            return await _responseProcessor.ProcessRequest<IEnumerable<Playlist>>(Endpoints.MetaData.GetPlaylists(), MetaCacheExpiry);
        }

        public async Task<IEnumerable<RequisitionPack>> GetRequisitionPacks()
        {
            return await _responseProcessor.ProcessRequest<IEnumerable<RequisitionPack>>(Endpoints.MetaData.GetRequisitionPacks(), MetaCacheExpiry);
        }

        public async Task<RequisitionPack> GetRequisitionPack(Guid id)
        {
            return await _responseProcessor.ProcessRequest<RequisitionPack>(Endpoints.MetaData.GetRequisitionPack(id), MetaCacheExpiry);
        }

        public async Task<RequisitionPack> GetRequisition(Guid id)
        {
            return await _responseProcessor.ProcessRequest<RequisitionPack>(Endpoints.MetaData.GetRequisition(id), MetaCacheExpiry);
        }

        public async Task<IEnumerable<Skull>> GetSkulls()
        {
            return await _responseProcessor.ProcessRequest<IEnumerable<Skull>>(Endpoints.MetaData.GetSkulls(), MetaCacheExpiry);
        }

        public async Task<IEnumerable<SpartanRank>> GetSpartanRanks()
        {
            return await _responseProcessor.ProcessRequest<IEnumerable<SpartanRank>>(Endpoints.MetaData.GetSpartanRanks(), MetaCacheExpiry);
        }

        public async Task<IEnumerable<TeamColor>> GetTeamColours()
        {
            return await _responseProcessor.ProcessRequest<IEnumerable<TeamColor>>(Endpoints.MetaData.GetTeamColors(), MetaCacheExpiry);
        }

        public async Task<IEnumerable<Vehicle>> GetVehicles()
        {
            return await _responseProcessor.ProcessRequest<IEnumerable<Vehicle>>(Endpoints.MetaData.GetVehicles(), MetaCacheExpiry);
        }

        public async Task<IEnumerable<Weapon>> GetWeapons()
        {
            return await _responseProcessor.ProcessRequest<IEnumerable<Weapon>>(Endpoints.MetaData.GetWeapons(), MetaCacheExpiry);
        }

        public async Task<IEnumerable<Season>> GetSeasons()
        {
            return await _responseProcessor.ProcessRequest<IEnumerable<Season>>(Endpoints.MetaData.GetSeasons(), MetaCacheExpiry);
        }

        #endregion

        #region Profile
        public async Task<Image> GetProfileEmblem(string gamerTag, int size = 256)
        {
            return await _responseProcessor.ProcessImageRequest(Endpoints.Profile.GetEmblemImage(gamerTag, size), ProfileCacheExpiry);
        }

        public async Task<Image> GetSpartanImage(string gamerTag, int size = 256, CropType cropType = CropType.Full)
        {
            return await _responseProcessor.ProcessImageRequest(Endpoints.Profile.GetSpartanImage(gamerTag, size, cropType), ProfileCacheExpiry);
        }
        #endregion

        #region UGC

        /// <summary>
        /// Get a specific UGC Game Variant for a specific player via id
        /// </summary>
        /// <param name="gamerTag">Players gamertag</param>
        /// <param name="variantId">Id of the game variant</param>
        /// <returns></returns>
        public async Task<UGCGameVariant> GetUGCGameVariant(string gamerTag, string variantId)
        {
            if (string.IsNullOrEmpty(gamerTag))
            {
                throw new HaloAPIException(CommonErrorMessages.InvalidGamerTag);
            }
            return await _responseProcessor.ProcessRequest<UGCGameVariant>(Endpoints.UGC.GetGameVariant(gamerTag, variantId), UGCCacheExpiry);
        }

        /// <summary>
        /// Get a specific UGC Map Variant for a specific player via id
        /// </summary>
        /// <param name="gamerTag">Players gamertag</param>
        /// <param name="variantId">Id of the game variant</param>
        /// <returns></returns>
        public async Task<UGCBase> GetUGCMapVariant(string gamerTag, string variantId)
        {
            if (string.IsNullOrEmpty(gamerTag))
            {
                throw new HaloAPIException(CommonErrorMessages.InvalidGamerTag);
            }
            return await _responseProcessor.ProcessRequest<UGCBase>(Endpoints.UGC.GetMapVariant(gamerTag, variantId), UGCCacheExpiry);
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
        public async Task<UGCSearchResult<UGCBase>> GetUGCMapVariants(string gamerTag, int start, int count, Sort sort, Order order )
        {
            if (string.IsNullOrEmpty(gamerTag))
            {
                throw new HaloAPIException(CommonErrorMessages.InvalidGamerTag);
            }
            return await _responseProcessor.ProcessRequest<UGCSearchResult<UGCBase>>(Endpoints.UGC.ListMapVariants(gamerTag, start, count, sort, order), UGCCacheExpiry);
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
        public async Task<UGCSearchResult<UGCBase>> GetUGCGameVariants(string gamerTag, int start, int count, Sort sort, Order order )
        {
            if (string.IsNullOrEmpty(gamerTag))
            {
                throw new HaloAPIException(CommonErrorMessages.InvalidGamerTag);
            }
            return await _responseProcessor.ProcessRequest<UGCSearchResult<UGCBase>>(Endpoints.UGC.ListGameVariants(gamerTag, start, count, sort, order), UGCCacheExpiry);
        }
        #endregion
    }
}
