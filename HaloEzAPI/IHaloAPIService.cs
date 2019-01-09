using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Threading.Tasks;
using HaloEzAPI.Abstraction.Enum.Halo5;
using HaloEzAPI.Model.Response.MetaData.Halo5;
using HaloEzAPI.Model.Response.MetaData.HaloWars2;
using HaloEzAPI.Model.Response.MetaData.HaloWars2.Shared;
using HaloEzAPI.Model.Response.MetaData.HaloWars2.Views;
using HaloEzAPI.Model.Response.Stats.Halo5;
using HaloEzAPI.Model.Response.Stats.Halo5.Arena;
using HaloEzAPI.Model.Response.Stats.Halo5.Campaign;
using HaloEzAPI.Model.Response.Stats.Halo5.CustomGame;
using HaloEzAPI.Model.Response.Stats.Halo5.Warzone;

namespace HaloEzAPI
{
    public interface IHaloAPIService
    {
        #region Halo 5
        //Stats
        Task<PlayerMatches> GetMatchesForPlayer(string gamerTag, GameMode gameMode, int start, int count, bool bustCache = false);
        Task<ArenaPostGameReport> GetArenaPostGameCarnageReport(Guid matchId, bool bustCache = false);
        Task<CampaignPostGameReport> GetCampaignPostGameCarnageReport(Guid matchId, bool bustCache = false);
        Task<CustomPostGameReport> GetCustomPostGameCarnageReport(Guid matchId, bool bustCache = false);
        Task<WarzonePostGameReport> GetWarzonePostGameCarnageReport(Guid matchId, bool bustCache = false);
        Task<ArenaServiceRecordQueryResponse> GetArenaServiceRecords([MaxLength(32)] string[] players, string seasonId = "", bool bustCache = false);
        Task<CampaignServiceRecordQueryResponse> GetCampaignServiceRecords([MaxLength(32)] string[] players, bool bustCache = false);
        Task<CustomGameServiceRecordQueryResponse> GetCustomGameServiceRecords([MaxLength(32)] string[] players, bool bustCache = false);
        Task<WarzoneServiceRecordQueryResponse> GetWarzoneServiceRecords([MaxLength(32)] string[] players, bool bustCache = false);
        
        //MetaData
        Task<IEnumerable<CampaignMission>> GetCampaignMissions(bool bustCache = false);
        Task<IEnumerable<Commendation>> GetCommendations(bool bustCache = false);
        Task<IEnumerable<CSRDesignation>> GetCSRDesignations(bool bustCache = false);
        Task<IEnumerable<Enemy>> GetEnemies(bool bustCache = false);
        Task<IEnumerable<FlexibleStat>> GetFlexibleStats(bool bustCache = false);
        Task<IEnumerable<GameBaseVariant>> GetGameBaseVariants(bool bustCache = false);
        Task<GameVariant> GetGameVariant(string id, bool bustCache = false);
        Task<IEnumerable<Impulse>> GetImpulses(bool bustCache = false);
        Task<MapVariant> GetMapVariant(string id, bool bustCache = false);
        Task<IEnumerable<Map>> GetMaps(bool bustCache = false);
        Task<IEnumerable<Medal>> GetMedals(bool bustCache = false);
        Task<IEnumerable<Playlist>> GetPlaylists(bool bustCache = false);
        Task<RequisitionPack> GetRequisitionPack(Guid id, bool bustCache = false);
        Task<RequisitionPack> GetRequisition(Guid id, bool bustCache = false);
        Task<IEnumerable<Skull>> GetSkulls(bool bustCache = false);
        Task<IEnumerable<SpartanRank>> GetSpartanRanks(bool bustCache = false);
        Task<IEnumerable<TeamColor>> GetTeamColours(bool bustCache = false);
        Task<IEnumerable<Vehicle>> GetVehicles(bool bustCache = false);
        Task<IEnumerable<Weapon>> GetWeapons(bool bustCache = false);
        Task<IEnumerable<Season>> GetSeasons(bool bustCache = false);

        //Profile
        Task<Image> GetProfileEmblem(string gamerTag, int size = 256, bool bustCache = false);
        Task<Image> GetSpartanImage(string gamerTag, int size = 256, CropType cropType = CropType.Full, bool bustCache = false);
        #endregion

        #region Halo Wars 2
        //MetaData

        #endregion

    }
}
