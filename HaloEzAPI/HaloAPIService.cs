using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Drawing;
using System.Threading.Tasks;
using HaloEzAPI.Abstraction.Enum.Halo5;
using HaloEzAPI.Abstraction.Interfaces;
using HaloEzAPI.Caching;
using HaloEzAPI.Limits;
using HaloEzAPI.Model.Request;
using HaloEzAPI.Model.Response.Error;
using HaloEzAPI.Model.Response.MetaData.Halo5;
using HaloEzAPI.Model.Response.MetaData.HaloWars2;
using HaloEzAPI.Model.Response.MetaData.HaloWars2.Campaign;
using HaloEzAPI.Model.Response.MetaData.HaloWars2.Cards;
using HaloEzAPI.Model.Response.MetaData.HaloWars2.Shared;
using HaloEzAPI.Model.Response.MetaData.HaloWars2.Views;
using HaloEzAPI.Model.Response.Stats.Halo5;
using HaloEzAPI.Model.Response.Stats.Halo5.Arena;
using HaloEzAPI.Model.Response.Stats.Halo5.Campaign;
using HaloEzAPI.Model.Response.Stats.Halo5.CustomGame;
using HaloEzAPI.Model.Response.Stats.Halo5.Warzone;
using HaloEzAPI.Model.Response.UGC;

namespace HaloEzAPI
{
    public class HaloAPIService : IHaloAPIService
    {
        private readonly ResponseProcessor _responseProcessor;
        private readonly int _statCacheExpiry = 1;
        private static readonly int _metaCacheExpiry = 24;
        private readonly int _profileCacheExpiry = 24;
        private readonly int _ugcCacheExpiry = 2;
        private const string BaseApiUrl = "https://www.haloapi.com";

        public HaloWars2APIService HaloWars2;

        public HaloAPIService(HaloAPIConfig config, IApiCacheManager apiCache = null)
        {
            Endpoints.Halo5.MajorPrefix = config.BaseApiUrl;
            _statCacheExpiry = config.StatCacheExpiry;
            _profileCacheExpiry = config.ProfileCacheExpiry;
            _ugcCacheExpiry = config.UGCCacheExpiry;
            RequestRateHttpClient.SetAPIToken(config.APIToken);
            if (apiCache == null)
            {
                apiCache = SingletonCacheManager.Instance;
            }
            _responseProcessor = new ResponseProcessor(apiCache);
            HaloWars2 = new HaloWars2APIService(_responseProcessor, config.APIToken, apiCache);
        }

        public HaloAPIService(string apiToken, string baseApiUrl = BaseApiUrl, IApiCacheManager apiCache = null)
        {
            Endpoints.Halo5.MajorPrefix = baseApiUrl;

            RequestRateHttpClient.SetAPIToken(apiToken);
            if (apiCache == null)
            {
                apiCache = SingletonCacheManager.Instance;
            }
            _responseProcessor = new ResponseProcessor(apiCache);
            HaloWars2 = new HaloWars2APIService(_responseProcessor, baseApiUrl, apiCache);
        }

        public class HaloWars2APIService
        {
            private readonly ResponseProcessor _responseProcessor;
            public HaloWars2APIService(ResponseProcessor responseProcessor, string baseApiUrl = BaseApiUrl, IApiCacheManager apiCache = null)
            {
                Endpoints.HaloWars2.MajorPrefix = baseApiUrl;
                _responseProcessor = responseProcessor;
            }

            #region MetaData
            public async Task<HW2Result<CampaignContentItem>> GetCampaignLevels(int startAt = 0, bool bustCache = false)
            {
                return await _responseProcessor.ProcessRequest<HW2Result<CampaignContentItem>>(Endpoints.HaloWars2.MetaData.GetCampaignLevels(startAt), _metaCacheExpiry, bustCache);
            }

            public async Task<HW2Result<CampaignLogContentItem>> GetCampaignLogs(int startAt = 0, bool bustCache = false)
            {
                return await _responseProcessor.ProcessRequest<HW2Result<CampaignLogContentItem>>(Endpoints.HaloWars2.MetaData.GetCampaignLogs(startAt), _metaCacheExpiry, bustCache);
            }

            public async Task<HW2Result<HW2ApiItem<CardKeywordView>>> GetCardKeywords(int startAt = 0, bool bustCache = false)
            {
                return await _responseProcessor.ProcessRequest<HW2Result<HW2ApiItem<CardKeywordView>>>(Endpoints.HaloWars2.MetaData.GetCardKeywords(startAt), _metaCacheExpiry, bustCache);
            }  
          
            public async Task<HW2Result<HW2ApiItem<HW2CardView>>> GetCards(int startAt = 0, bool bustCache = false)
            {
                return await _responseProcessor.ProcessRequest<HW2Result<HW2ApiItem<HW2CardView>>>(Endpoints.HaloWars2.MetaData.GetCards(startAt), _metaCacheExpiry, bustCache);
            }

            public async Task<HW2Result<HW2ApiItem<HW2CSRDesignationView>>> GetCSRDesignations(int startAt = 0, bool bustCache = false)
            {
                return await _responseProcessor.ProcessRequest<HW2Result<HW2ApiItem<HW2CSRDesignationView>>>(Endpoints.HaloWars2.MetaData.GetCSRDesignations(startAt), _metaCacheExpiry, bustCache);
            }

            public async Task<HW2Result<HW2ApiItem<HW2DifficultyView>>> GetDifficulties(int startAt = 0, bool bustCache = false)
            {
                return await _responseProcessor.ProcessRequest<HW2Result<HW2ApiItem<HW2DifficultyView>>>(Endpoints.HaloWars2.MetaData.GetDifficulties(startAt), _metaCacheExpiry, bustCache);
            }

            public async Task<HW2Result<HW2ApiItem<BaseView>>> GetGameObjectCategories(int startAt = 0, bool bustCache = false)
            {
                return await _responseProcessor.ProcessRequest<HW2Result<HW2ApiItem<BaseView>>>(Endpoints.HaloWars2.MetaData.GetGameObjectCategories(startAt), _metaCacheExpiry, bustCache);
            }

            public async Task<HW2Result<HW2ApiItem<HW2ObjectView>>> GetGameObjects(int startAt = 0, bool bustCache = false)
            {
                return await _responseProcessor.ProcessRequest<HW2Result<HW2ApiItem<HW2ObjectView>>>(Endpoints.HaloWars2.MetaData.GetGameObjects(startAt), _metaCacheExpiry, bustCache);
            }

            public async Task<HW2Result<HW2ApiItem<HW2LeaderPowerView>>> GetLeaderPowers(int startAt = 0, bool bustCache = false)
            {
                return await _responseProcessor.ProcessRequest<HW2Result<HW2ApiItem<HW2LeaderPowerView>>>(Endpoints.HaloWars2.MetaData.GetLeaderPowers(startAt), _metaCacheExpiry, bustCache);
            }
            public async Task<HW2Result<HW2ApiItem<HW2LeaderView>>> GetLeaders(int startAt = 0, bool bustCache = false)
            {
                return await _responseProcessor.ProcessRequest<HW2Result<HW2ApiItem<HW2LeaderView>>>(Endpoints.HaloWars2.MetaData.GetLeaders(startAt), _metaCacheExpiry, bustCache);
            }
            public async Task<HW2Result<HW2ApiItem<HW2PlaylistView>>> GetPlaylists(int startAt = 0, bool bustCache = false)
            {
                // TODO: Expand PlaylistView
                Console.WriteLine("Not Implemented yet, result will be partial");
                return await _responseProcessor.ProcessRequest<HW2Result<HW2ApiItem<HW2PlaylistView>>>(Endpoints.HaloWars2.MetaData.GetPlaylists(startAt), _metaCacheExpiry, bustCache);
            }
            #endregion
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
            return await _responseProcessor.ProcessRequest<PlayerMatches>(Endpoints.Halo5.Stats.GetMatchesForPlayer(gamerTag, gameMode, start, count), _statCacheExpiry, bustCache);
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
            return await _responseProcessor.ProcessRequest<PlayerLeaderboardResults>(Endpoints.Halo5.Stats.PlayerLeaderboard(seasonId, playlistId, count), _statCacheExpiry, bustCache);
        }

        public async Task<MatchEvent> GetEventsForMatch(string matchId, bool bustCache = false)
        {
            if (string.IsNullOrEmpty(matchId))
            {
                throw new HaloAPIException(CommonErrorMessages.InvalidMatchId);
            }
            return await _responseProcessor.ProcessRequest<MatchEvent>(Endpoints.Halo5.Stats.GetEventsForMatch(matchId), _statCacheExpiry, bustCache);
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
            return await _responseProcessor.ProcessRequest<ArenaPostGameReport>(Endpoints.Halo5.Stats.GetPostGameCarnageReport(matchId.ToString(), GameMode.Arena), _statCacheExpiry, bustCache);
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
            return await _responseProcessor.ProcessRequest<CampaignPostGameReport>(Endpoints.Halo5.Stats.GetPostGameCarnageReport(matchId.ToString(), GameMode.Campaign), _statCacheExpiry, bustCache);
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
            return await _responseProcessor.ProcessRequest<CustomPostGameReport>(Endpoints.Halo5.Stats.GetPostGameCarnageReport(matchId.ToString(), GameMode.Custom), _statCacheExpiry, bustCache);
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
            return await _responseProcessor.ProcessRequest<WarzonePostGameReport>(Endpoints.Halo5.Stats.GetPostGameCarnageReport(matchId.ToString(), GameMode.Warzone), _statCacheExpiry, bustCache);
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
            return await _responseProcessor.ProcessRequest<ArenaServiceRecordQueryResponse>(Endpoints.Halo5.Stats.GetServiceRecords(players, GameMode.Arena, seasonId), _statCacheExpiry, bustCache);
        }        
        
        /// <summary>
        /// Get Campaign Service Record for specified list of players
        /// </summary>
        /// <param name="players">Up to 32 players can be requested></param>
        /// <returns></returns>
        public async Task<CampaignServiceRecordQueryResponse> GetCampaignServiceRecords([MaxLength(32)]string[] players, bool bustCache = false)
        {
            return await _responseProcessor.ProcessRequest<CampaignServiceRecordQueryResponse>(Endpoints.Halo5.Stats.GetServiceRecords(players, GameMode.Campaign), _statCacheExpiry, bustCache);
        }

        /// <summary>
        /// Get Custom Game Service Record for specified list of players
        /// </summary>
        /// <param name="players">Up to 32 players can be requested></param>
        /// <returns></returns>
        public async Task<CustomGameServiceRecordQueryResponse> GetCustomGameServiceRecords([MaxLength(32)] string[] players, bool bustCache = false)
        {
            return await _responseProcessor.ProcessRequest<CustomGameServiceRecordQueryResponse>(Endpoints.Halo5.Stats.GetServiceRecords(players, GameMode.Custom), _statCacheExpiry, bustCache);
        }

        /// <summary>
        /// Get Warzone Service Record for specified list of players
        /// </summary>
        /// <param name="players">Up to 32 players can be requested></param>
        /// <returns></returns>
        public async Task<WarzoneServiceRecordQueryResponse> GetWarzoneServiceRecords([MaxLength(32)] string[] players, bool bustCache = false)
        {
            return await _responseProcessor.ProcessRequest<WarzoneServiceRecordQueryResponse>(Endpoints.Halo5.Stats.GetServiceRecords(players, GameMode.Warzone), _statCacheExpiry, bustCache);
        }
        #endregion

        #endregion 

        #region MetaData

        public async Task<IEnumerable<CampaignMission>> GetCampaignMissions(bool bustCache = false)
        {
            return await _responseProcessor.ProcessRequest<IEnumerable<CampaignMission>>(Endpoints.Halo5.MetaData.GetCampaignMissions(), _metaCacheExpiry, bustCache);
        }

        public async Task<IEnumerable<Commendation>> GetCommendations(bool bustCache = false)
        {
            return await _responseProcessor.ProcessRequest<IEnumerable<Commendation>>(Endpoints.Halo5.MetaData.GetCommendations(), _metaCacheExpiry, bustCache);
        }

        public async Task<IEnumerable<CSRDesignation>> GetCSRDesignations(bool bustCache = false)
        {
            return await _responseProcessor.ProcessRequest<IEnumerable<CSRDesignation>>(Endpoints.Halo5.MetaData.GetCSRDesignations(), _metaCacheExpiry, bustCache);
        }

        public async Task<IEnumerable<Enemy>> GetEnemies(bool bustCache = false)
        {
            return await _responseProcessor.ProcessRequest<IEnumerable<Enemy>>(Endpoints.Halo5.MetaData.GetEnemies(), _metaCacheExpiry, bustCache);
        }

        public async Task<IEnumerable<FlexibleStat>> GetFlexibleStats(bool bustCache = false)
        {
            return await _responseProcessor.ProcessRequest<IEnumerable<FlexibleStat>>(Endpoints.Halo5.MetaData.GetFlexibleStats(), _metaCacheExpiry, bustCache);
        }

        public async Task<IEnumerable<GameBaseVariant>> GetGameBaseVariants(bool bustCache = false)
        {
            return await _responseProcessor.ProcessRequest<IEnumerable<GameBaseVariant>>(Endpoints.Halo5.MetaData.GetGameBaseVariants(), _metaCacheExpiry, bustCache);
        }

        public async Task<GameVariant> GetGameVariant(string id, bool bustCache = false)
        {
            return await _responseProcessor.ProcessRequest<GameVariant>(Endpoints.Halo5.MetaData.GetGameVariant(id), _metaCacheExpiry, bustCache);
        }

        public async Task<IEnumerable<Impulse>> GetImpulses(bool bustCache = false)
        {
            return await _responseProcessor.ProcessRequest<IEnumerable<Impulse>>(Endpoints.Halo5.MetaData.GetImpulses(), _metaCacheExpiry, bustCache);
        }

        public async Task<MapVariant> GetMapVariant(string id, bool bustCache = false)
        {
            return await _responseProcessor.ProcessRequest<MapVariant>(Endpoints.Halo5.MetaData.GetMapVariants(id), _metaCacheExpiry, bustCache);
        }

        public async Task<IEnumerable<Map>> GetMaps(bool bustCache = false)
        {
            return await _responseProcessor.ProcessRequest<IEnumerable<Map>>(Endpoints.Halo5.MetaData.GetMaps(), _metaCacheExpiry, bustCache);
        }

        public async Task<IEnumerable<Medal>> GetMedals(bool bustCache = false)
        {
            return await _responseProcessor.ProcessRequest<IEnumerable<Medal>>(Endpoints.Halo5.MetaData.GetMedals(), _metaCacheExpiry, bustCache);
        }

        public async Task<IEnumerable<Playlist>> GetPlaylists(bool bustCache = false)
        {
            return await _responseProcessor.ProcessRequest<IEnumerable<Playlist>>(Endpoints.Halo5.MetaData.GetPlaylists(), _metaCacheExpiry, bustCache);
        }

        public async Task<IEnumerable<RequisitionPack>> GetRequisitionPacks(bool bustCache = false)
        {
            return await _responseProcessor.ProcessRequest<IEnumerable<RequisitionPack>>(Endpoints.Halo5.MetaData.GetRequisitionPacks(), _metaCacheExpiry, bustCache);
        }

        public async Task<RequisitionPack> GetRequisitionPack(Guid id, bool bustCache = false)
        {
            return await _responseProcessor.ProcessRequest<RequisitionPack>(Endpoints.Halo5.MetaData.GetRequisitionPack(id), _metaCacheExpiry, bustCache);
        }

        public async Task<RequisitionPack> GetRequisition(Guid id, bool bustCache = false)
        {
            return await _responseProcessor.ProcessRequest<RequisitionPack>(Endpoints.Halo5.MetaData.GetRequisition(id), _metaCacheExpiry, bustCache);
        }

        public async Task<IEnumerable<Skull>> GetSkulls(bool bustCache = false)
        {
            return await _responseProcessor.ProcessRequest<IEnumerable<Skull>>(Endpoints.Halo5.MetaData.GetSkulls(), _metaCacheExpiry, bustCache);
        }

        public async Task<IEnumerable<SpartanRank>> GetSpartanRanks(bool bustCache = false)
        {
            return await _responseProcessor.ProcessRequest<IEnumerable<SpartanRank>>(Endpoints.Halo5.MetaData.GetSpartanRanks(), _metaCacheExpiry, bustCache);
        }

        public async Task<IEnumerable<TeamColor>> GetTeamColours(bool bustCache = false)
        {
            return await _responseProcessor.ProcessRequest<IEnumerable<TeamColor>>(Endpoints.Halo5.MetaData.GetTeamColors(), _metaCacheExpiry, bustCache);
        }

        public async Task<IEnumerable<Vehicle>> GetVehicles(bool bustCache = false)
        {
            return await _responseProcessor.ProcessRequest<IEnumerable<Vehicle>>(Endpoints.Halo5.MetaData.GetVehicles(), _metaCacheExpiry, bustCache);
        }

        public async Task<IEnumerable<Weapon>> GetWeapons(bool bustCache = false)
        {
            return await _responseProcessor.ProcessRequest<IEnumerable<Weapon>>(Endpoints.Halo5.MetaData.GetWeapons(), _metaCacheExpiry, bustCache);
        }

        public async Task<IEnumerable<Season>> GetSeasons(bool bustCache = false)
        {
            return await _responseProcessor.ProcessRequest<IEnumerable<Season>>(Endpoints.Halo5.MetaData.GetSeasons(), _metaCacheExpiry, bustCache);
        }

        #endregion

        #region Profile
        public async Task<Image> GetProfileEmblem(string gamerTag, int size = 256, bool bustCache = false)
        {
            return await _responseProcessor.ProcessImageRequest(Endpoints.Halo5.Profile.GetEmblemImage(gamerTag, size), _profileCacheExpiry, bustCache);
        }

        public async Task<Image> GetSpartanImage(string gamerTag, int size = 256, CropType cropType = CropType.Full, bool bustCache = false)
        {
            return await _responseProcessor.ProcessImageRequest(Endpoints.Halo5.Profile.GetSpartanImage(gamerTag, size, cropType), _profileCacheExpiry, bustCache);
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
            return await _responseProcessor.ProcessRequest<UGCGameVariant>(Endpoints.Halo5.UGC.GetGameVariant(gamerTag, variantId), _ugcCacheExpiry, bustCache);
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
            return await _responseProcessor.ProcessRequest<UGCBase>(Endpoints.Halo5.UGC.GetMapVariant(gamerTag, variantId), _ugcCacheExpiry, bustCache);
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
            return await _responseProcessor.ProcessRequest<UGCSearchResult<UGCBase>>(Endpoints.Halo5.UGC.ListMapVariants(gamerTag, start, count, sort, order), _ugcCacheExpiry, bustCache);
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
            return await _responseProcessor.ProcessRequest<UGCSearchResult<UGCBase>>(Endpoints.Halo5.UGC.ListGameVariants(gamerTag, start, count, sort, order), _ugcCacheExpiry, bustCache);
        }
        #endregion
    }
}
